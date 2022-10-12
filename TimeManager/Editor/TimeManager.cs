using UnityEngine;

namespace Eazax.Editor
{

    /// <summary>
    /// 时间管理器
    /// </summary>
    /// <author>陈皮皮</author>
    /// <version>20221010</version>
    public static class TimeManager
    {

        /// <summary>
        ///   <para>The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.</para>
        /// </summary>
        public static float fixedTimestep
        {
            get => Time.fixedDeltaTime;
            set => Time.fixedDeltaTime = value;
        }

        /// <summary>
        ///   <para>The maximum time a frame can take. Physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) will be performed only for this duration of time per frame.</para>
        /// </summary>
        public static float maximumAllowedTimestep
        {
            get => Time.maximumDeltaTime;
            set => Time.maximumDeltaTime = value;
        }

        /// <summary>
        ///   <para>The scale at which time passes. This can be used for slow motion effects.</para>
        /// </summary>
        public static float timeScale
        {
            get => Time.timeScale;
            set => Time.timeScale = value;
        }

        /// <summary>
        ///   <para>The maximum time a frame can spend on particle updates. If the frame takes longer than this, then updates are split into multiple smaller updates.</para>
        /// </summary>
        public static float maximumParticleTimestep
        {
            get => Time.maximumParticleDeltaTime;
            set => Time.maximumParticleDeltaTime = value;
        }

        /// <summary>
        /// 重置
        /// </summary>
        public static void Reset()
        {
            fixedTimestep = 0.02f;
            maximumAllowedTimestep = 0.3333333f;
            timeScale = 1;
            maximumParticleTimestep = 0.03f;
        }

    }

}
