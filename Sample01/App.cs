using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace Sample01
{
    public class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // 当前程序集的路径
            var assemblyPath = Assembly.GetExecutingAssembly().Location;


            // 创建一个Tab
            var tabName = "自定义";
            application.CreateRibbonTab(tabName);

            // 在指定Tab上创建Panel
            var panel = application.CreateRibbonPanel(tabName, "自定义组");

            #region 按钮布局一：单按钮

            // 在Panel上添加一个按钮，这个按钮单独成为一个“Item”
            var pushButton = panel.AddItem(new PushButtonData(
                "HelloButton", $"你好！{Environment.NewLine}这是一个按钮",
                assemblyPath, "RevitDemos.HelloButton")) as PushButton;
            pushButton.ToolTip = "这里是按扭说明，鼠标放在按钮上会显示这段文字。";
            pushButton.Image = GetIcon();
            pushButton.LargeImage = GetIcon();

            #endregion

            #region 按钮布局二：堆排列按钮

            var pushButtonRed = new PushButtonData(
                "HelloRed", "Hello Red",
                assemblyPath, "RevitDemos.HelloButton");
            pushButtonRed.Image = GetIcon();

            var pushButtonBlue = new PushButtonData(
                "HelloBlue", "Hello Blue",
                assemblyPath, "RevitDemos.HelloButton");
            pushButtonBlue.Image = GetIcon();

            panel.AddStackedItems(pushButtonRed, pushButtonBlue);

            #endregion

            #region 按钮布局三：下拉式按钮

            var pulldownButton = panel.AddItem(
                new PulldownButtonData("Hello", "Hello Pulldown")) as PulldownButton;
            pulldownButton.Image = GetIcon();
            pulldownButton.LargeImage = GetIcon();

            var pushButtonFoo = pulldownButton.AddPushButton(
                new PushButtonData("HelloFoo", "Hello Foo", assemblyPath, "RevitDemos.HelloButton"));
            pushButtonFoo.Image = GetIcon();

            var pushButtonBar = pulldownButton.AddPushButton(
                new PushButtonData("HelloBar", "Hello Bar", assemblyPath, "RevitDemos.HelloButton"));
            pushButtonBar.Image = GetIcon();

            #endregion

            // 添加一条竖分隔线
            panel.AddSeparator();

            return Result.Succeeded;
        }

        private BitmapImage GetIcon()
        {
            // 只作为演示，实际项目中需要更换为对应的图片
            return new BitmapImage(new Uri($"pack://application:,,,/RevitDemos;component/Resources/demo.ico"));
        }
    }
}
