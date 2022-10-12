using System;
using UnityEditor;
using UnityEngine;

namespace Eazax.Editor
{

    /// <summary>
    /// 时间管理器窗口
    /// </summary>
    /// <author>陈皮皮</author>
    /// <version>20221012</version>
    public class TimeManagerWindow : EditorWindow
    {

        #region WindowDefine

        /// <summary>
        /// 窗口实例
        /// </summary>
        private static TimeManagerWindow _instance;

        /// <summary>
        /// 展示窗口
        /// </summary>
        [MenuItem("Window/Time Manager")]
        public static void ShowWindow()
        {
            _instance = GetWindow(typeof(TimeManagerWindow)) as TimeManagerWindow;
            if (_instance == null)
            {
                throw new Exception("Failed to open window!");
            }
            // 设置窗口标题
            GUIContent iconContent = EditorGUIUtility.IconContent("UnityEditor.AnimationWindow");
            _instance.titleContent = iconContent != null ? new GUIContent("Time Manager", iconContent.image) : new GUIContent("Time Manager");
            // 设置窗口尺寸
            _instance.minSize = new Vector2(300, 110);
            SetWindowSize(_instance, 400, 212);
            // 使窗口居中于编辑器
            CenterWindow(_instance, 0, -100);
        }

        /// <summary>
        /// OnDestroy is called to close the EditorWindow window.
        /// </summary>
        private void OnDestroy()
        {
            _instance = null;
        }

        #endregion

        #region GUI

        #region GUIContents

        private readonly GUIContent _optionsTitleLabel = new GUIContent("Options", "");

        private readonly GUIContent _shortcutsTitleLabel = new GUIContent("Shortcuts", "");

        private readonly GUIContent _timeScaleTitleLabel = new GUIContent("Time Scale", "");

        private readonly GUIContent _fixedTimestepLabel = new GUIContent("Fixed Timestep",
            "The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.");

        private readonly GUIContent _maximumAllowedTimestepLabel = new GUIContent("Maximum Allowed Timestep",
            "The maximum time a frame can take. Physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) will be performed only for this duration of time per frame.");

        private readonly GUIContent _timeScaleLabel = new GUIContent("Time Scale", "The scale at which time passes. This can be used for slow motion effects.");

        private readonly GUIContent _maximumParticleTimestepLabel = new GUIContent("Maximum Particle Timestep",
            "The maximum time a frame can spend on particle updates. If the frame takes longer than this, then updates are split into multiple smaller updates.");

        private readonly GUIContent _resetLabel = new GUIContent("Reset", "");

        private readonly GUIContent _pauseLabel = new GUIContent("Pause", "");

        private readonly GUIContent _resumeLabel = new GUIContent("Resume", "");

        #endregion

        #region GUILayoutConfigs

        private const int _paddingY = 10;

        private const int _paddingX = 5;

        private const int _spacing = 5;

        #endregion

        /// <summary>
        /// 绘制 GUI
        /// </summary>
        private void OnGUI()
        {
            GUILayout.Space(_paddingY);
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Space(_paddingX);
                EditorGUILayout.BeginVertical();
                {
                    // 选项
                    OnOptionGUI();
                    GUILayout.Space(_spacing);
                    // 按钮
                    OnButtonGUI();
                    GUILayout.Space(_spacing);
                    // 按钮
                    OnButton2GUI();
                    GUILayout.Space(_spacing);
                }
                EditorGUILayout.EndVertical();
                GUILayout.Space(_paddingX);
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.FlexibleSpace();
        }

        private void OnOptionGUI()
        {
            // 标题
            EditorGUILayout.LabelField(_optionsTitleLabel, MyStyles.TitleStyle);
            // 内容
            EditorGUILayout.BeginVertical();
            {
                // fixedTimestep
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(_fixedTimestepLabel);
                    TimeManager.fixedTimestep = EditorGUILayout.FloatField(TimeManager.fixedTimestep);
                }
                EditorGUILayout.EndHorizontal();
                // maximumAllowedTimestep
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(_maximumAllowedTimestepLabel);
                    TimeManager.maximumAllowedTimestep = EditorGUILayout.FloatField(TimeManager.maximumAllowedTimestep);
                }
                EditorGUILayout.EndHorizontal();
                // timeScale
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(_timeScaleLabel);
                    TimeManager.timeScale = EditorGUILayout.FloatField(TimeManager.timeScale);
                }
                EditorGUILayout.EndHorizontal();
                // maximumParticleTimestep
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(_maximumParticleTimestepLabel);
                    TimeManager.maximumParticleTimestep = EditorGUILayout.FloatField(TimeManager.maximumParticleTimestep);
                }
                EditorGUILayout.EndHorizontal();
                // TimeManager.timeScale = EditorGUILayout.Slider(_timeScaleLabel, TimeManager.timeScale, 0, 100);
            }
            EditorGUILayout.EndVertical();
        }

        private void OnButtonGUI()
        {
            // 标题
            EditorGUILayout.LabelField(_shortcutsTitleLabel, MyStyles.TitleStyle);
            // 内容
            EditorGUILayout.BeginHorizontal();
            {
                // 重置按钮
                if (GUILayout.Button(_resetLabel, GUILayout.Width(100)))
                {
                    TimeManager.Reset();
                }
                // 暂停/继续
                if (TimeManager.timeScale == 0)
                {
                    // 继续按钮
                    if (GUILayout.Button(_resumeLabel))
                    {
                        TimeManager.timeScale = 1;
                    }
                }
                else
                {
                    // 暂停按钮
                    if (GUILayout.Button(_pauseLabel))
                    {
                        TimeManager.timeScale = 0;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        private void OnButton2GUI()
        {
            // 标题
            EditorGUILayout.LabelField(_timeScaleTitleLabel, MyStyles.TitleStyle);
            // 内容
            EditorGUILayout.BeginHorizontal();
            {
                // 
                if (GUILayout.Button(new GUIContent("x0")))
                {
                    TimeManager.timeScale = 0;
                }
                // 
                if (GUILayout.Button(new GUIContent("x0.5")))
                {
                    TimeManager.timeScale = 0.5f;
                }
                // 
                if (GUILayout.Button(new GUIContent("x1")))
                {
                    TimeManager.timeScale = 1;
                }
                // 
                if (GUILayout.Button(new GUIContent("x2")))
                {
                    TimeManager.timeScale = 2;
                }
                // 
                if (GUILayout.Button(new GUIContent("x4")))
                {
                    TimeManager.timeScale = 4;
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        #endregion

        #region GUIStyles

        /// <summary>
        /// 风格
        /// </summary>
        private static class MyStyles
        {

            /// <summary>
            /// 工具栏行风格
            /// </summary>
            public static readonly GUIStyle TitleStyle = new GUIStyle(EditorStyles.boldLabel);

            /// <summary>
            /// 表格头部文本风格
            /// </summary>
            public static readonly GUIStyle TableHeaderLabelStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                alignment = TextAnchor.MiddleCenter,
                stretchWidth = true,
                stretchHeight = true,
            };

        }

        #endregion

        #region UtilityFunctions

        /// <summary>
        /// 创建一个单色纹理
        /// </summary>
        /// <param name="color">颜色</param>
        /// <returns></returns>
        private static Texture2D MakeSingleColorTexture(Color color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixels(new Color[] { color });
            texture.Apply();
            return texture;
        }

        /// <summary>
        /// 获取 Unity 内置 GUI 风格
        /// </summary>
        /// <param name="styleName">风格名称</param>
        /// <returns></returns>
        private static GUIStyle GetBuiltinGUIStyle(string styleName)
        {
            GUIStyle style = GUI.skin.FindStyle(styleName) ?? EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).FindStyle(styleName);
            if (style == null)
            {
                Debug.LogError((object)("Missing built-in guistyle " + styleName));
            }
            return style;
        }

        /// <summary>
        /// 设置窗口尺寸
        /// </summary>
        /// <param name="window">窗口实例</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        public static void SetWindowSize(EditorWindow window, int width, int height)
        {
            Rect pos = window.position;
            pos.width = width;
            pos.height = height;
            window.position = pos;
        }

        /// <summary>
        /// 使窗口居中（基于 Unity 编辑器主窗口）
        /// </summary>
        /// <param name="window">窗口实例</param>
        /// <param name="offsetX">水平偏移</param>
        /// <param name="offsetY">垂直偏移</param>
        public static void CenterWindow(EditorWindow window, int offsetX = 0, int offsetY = 0)
        {
            Rect mainWindowPos = EditorGUIUtility.GetMainWindowPosition();
            Rect pos = window.position;
            float centerOffsetX = (mainWindowPos.width - pos.width) * 0.5f;
            float centerOffsetY = (mainWindowPos.height - pos.height) * 0.5f;
            pos.x = mainWindowPos.x + centerOffsetX + offsetX;
            pos.y = mainWindowPos.y + centerOffsetY + offsetY;
            window.position = pos;
        }

        #endregion

    }

}
