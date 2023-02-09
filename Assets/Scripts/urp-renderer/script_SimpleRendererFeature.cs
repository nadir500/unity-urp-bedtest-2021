using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class script_SimpleRendererFeature : ScriptableRendererFeature
{
    class SampleRenderPass : ScriptableRenderPass
    {
        private Material m_sampleMaterial;
        private Mesh m_sampleMesh;
        public SampleRenderPass(Material material, Mesh sampleMesh)
        {
            m_sampleMaterial = material;
            m_sampleMesh = sampleMesh;
        }
        // This method is called before executing the render pass.
        // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
        // When empty this render pass will render to the active camera render target.
        // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
        // The render pipeline will ensure target setup and clearing happens in a performant manner.
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {

        }

        // Here you can implement the rendering logic.
        // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
        // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
        // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            Debug.Log(message: "The Execute() method runs.");
            Camera currentCamera;
            Vector3 flareScale;
            CommandBuffer sampleCommandBuffer = CommandBufferPool.Get(name: "command_samplePass");
            //cmd buffer start
            currentCamera = renderingData.cameraData.camera;
            sampleCommandBuffer.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
            flareScale = new Vector3(.5f, currentCamera.aspect * .5f, .5f);
            for (int i = 0; i < renderingData.lightData.visibleLights.Length; i++)
            {
                VisibleLight currentLightIndex = renderingData.lightData.visibleLights[i];
                Light lightComponent = currentLightIndex.light;
                if (lightComponent.type == LightType.Point)
                {
                    Vector3 flarePosition = currentCamera.WorldToViewportPoint(lightComponent.transform.position) * 2 - Vector3.one;
                    flarePosition.z = 0;
                    Matrix4x4 flareMatrix4X4 = Matrix4x4.TRS(flarePosition,Quaternion.identity,flareScale); 
                    sampleCommandBuffer.DrawMesh(m_sampleMesh, flareMatrix4X4, m_sampleMaterial, 0, 0);
                }
            }
            //draw final command 
            //cmd buffer end
            context.ExecuteCommandBuffer(sampleCommandBuffer);
            CommandBufferPool.Release(sampleCommandBuffer);
        }

        // Cleanup any allocated resources that were created during the execution of this render pass.
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
        }
    }

    public Material sampleMaterial;
    public Mesh sampleMesh;
    SampleRenderPass m_ScriptablePass;

    /// <inheritdoc/>
    public override void Create()
    {
        m_ScriptablePass = new SampleRenderPass(sampleMaterial, sampleMesh);
        // Configures where the render pass should be injected.
        m_ScriptablePass.renderPassEvent = RenderPassEvent.AfterRenderingSkybox;
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (sampleMaterial != null && sampleMesh != null)
        {
            renderer.EnqueuePass(m_ScriptablePass);
        }
    }
}


