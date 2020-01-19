using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

//using System.Windows.Media.Imaging;

namespace ribbontabandbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Class1 : IExternalApplication
    {
        public string[] ImageList { get; set; }
        public string[] LargeImageList { get; set; }
        public string[] TooltipImageList { get; set; }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var assembly = Assembly.GetExecutingAssembly().Location;
            var className = "RevitDemos.HelloButton";

            var tabs = new[] { "轴网/柱子", "墙/梁", "门窗/楼板/面积", "房间/面积", "楼梯/其他", "详图/标注", };
            var panels = new string[][]{
                new[] { "楼层", "轴网创建", "轴网编辑", "轴号编辑", "柱子" },
                new[] { "墙体生成", "墙体编辑", "阳台", "墙体贴面/拆分", "幕墙", "梁" },
                new[] { "门窗", "楼板", "屋顶", "女儿墙", "老虎墙" },
                new[] { "标准库", "房间", "面积", "构件布置" },
                new[] { "楼梯", "电梯/扶梯", "台阶/散水", "车库", "坡道" },
                new[] { "剖面图/详图", "平、立面", "尺寸标注", "编辑标注", "符号标注" }
            };
            var buttons = new Dictionary<string, string[]>() {
                { "0:0" ,new[]{ "楼层设置", "附加标高" } },
                { "0:1", new[]{ "直线轴网", "弧线轴网", "线生轴网", "三维轴网", "轴网标注" } },
                { "0:2", new[]{ "添加轴线", "删除轴线", "轴线合并", "轴线剪裁" } },
                { "0:3", new[]{ "文字设置", "全局轴号", "分区编号", "主辅转换", "轴号重排", "连续轴号", "轴号对齐", "轴号隐现" } },
                { "0:4", new[]{ "柱子插入", "角柱插入", "按层分柱", "柱齐墙边", "墙齐柱边" } },

                { "1:0" ,new[]{ "绘制墙体", "轴网生墙|线生墙"} },
                { "1:1" ,new[]{ "外墙类型", "外墙朝向", "外墙对齐", "内墙对齐", "按层分墙", "墙体倒角", "墙体命名", "自动断墙", "墙体断开", "墙体连接", "拉伸" } },
                { "1:2" ,new[]{ "绘制阳台", "编辑阳台" } },
                { "1:3" ,new[]{ "添加保温", "外墙饰面", "内墙饰面", "柱子饰面", "多墙合并", "多墙修改", "墙体拆分" } },
                { "1:4" ,new[]{ "幕墙绘制|幕墙网格|幕墙竖艇" } },
                { "1:5" ,new[]{ "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" } },

                { "2:0" ,new[]{ "插入门", "插入窗", "内外翻转","左右翻转","门窗编号","门窗图例","刷新\r\n门窗图例","门窗表","刷新\r\n门窗表", "拆分表格" } },
                { "2:1" ,new[]{ "生成楼板", "自动拆分", "楼板合并", "楼板升降", "板变斜板"} },
                { "2:2" ,new[]{ "拉伸屋面", "面屋顶" } },
                { "2:3" ,new[]{ "自动\r\n女儿墙", "手动\r\n女儿墙", "编辑\r\n女儿墙" } },
                { "2:4" ,new[]{ "老虎墙" } },

                { "3:0", new[]{ "库管理","户型分发","户型拼接"} },
                { "3:1", new[] { "房间设置","房间编号","批量编号","房间分隔","标记居中","构件添加\r\n房间属性","三位标记","生成房间","房间标记","房间装饰","名称替换","房间做法" } } ,
                { "3:2", new[]{"面积显隐","建筑面积","套内面积","防火分区","防火分区\r\n缩略图","防火分区\r\n合并","面积统计","住宅\r\n面积表","其它\r\n面积表","颜色方案" } } ,
                { "3:3", new[]{ "家具布置","卫浴布置"} },

                { "4:0", new []{"双跑楼梯","多跑楼梯","连续直段","剪刀楼梯","钢梯", "双分平行|双分转角|交叉楼梯", "直段楼梯|弧形楼梯|双分三跑", "三角楼梯|矩形转角|梯梁合并", "编辑楼梯", "楼梯拆分|楼梯合并|面层显隐" } },
                { "4:1", new []{"电梯布置","删除电梯","自动扶梯","扶梯图例" } },
                { "4:2", new []{"绘制台阶","创建散水" } },
                { "4:3", new []{ "汽车坡道","编辑汽车\r\n坡道","汽车坡道\r\n展开图","车道线\r\n绘制","方向箭头\r\n放置","自动布车","车位编号","车位编号删除","车位统计"} },
                { "4:4", new []{"入门坡道", "无障碍\r\n坡道", "编辑无障\r\n碍坡道" } },

                { "5:0",new [] { "填充设置","楼梯\r\n平面详图","楼梯\r\n剖面详图","楼梯净高\r\n标注","楼梯净高\r\n标注删除","电梯\r\n平面详图","电梯\r\n剖面详图","剖面图","墙身详图"} },
                { "5:1",new [] { "一键平面","一键立面","里面轮廓\r\n创建","编辑立面轮廓","删除立面轮廓"} },
                { "5:2",new [] { "标注设置","门窗标注","墙厚标注","两点标注","内门标注","快速标注","层间标注","立面\r\n门窗标注", "轴网标注|对齐标注|线性标注", "角度标注|径向标注"} },
                { "5:3",new [] {"隐藏标注","连接尺寸","打断尺寸","合并区间", "位置取齐|线长取齐" } },
                { "5:4",new [] {"标高标注","坡度标注", "引线标注", "索引标注", "箭头标注", "做法标注", "加折断线", "图名标注" } }

            };

            LoadImageInfo();

            for (var i = 0; i < tabs.Length; i++)
            {
                application.CreateRibbonTab(tabs[i]);
                for (int j = 0; j < panels[i].Length; j++)
                {
                    var panel = application.CreateRibbonPanel(tabs[i], panels[i][j]);
                    var btnArr = buttons[i + ":" + j];
                    foreach (var btn in btnArr)
                    {
                        //用 |的出现 分割字符串
                        var subBtns = btn.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        //将所有的字符串变成button
                        var items = subBtns.Select(x => new PushButtonData(x, x, assembly, className)).ToList();
                        //给所有的button添加图片
                        foreach (var item in items)
                        {
                            item.Image = GetIcon(item.Name, ImageList);
                            item.LargeImage = GetIcon(item.Name, LargeImageList);
                            item.ToolTipImage = GetIcon(item.Name, TooltipImageList);
                        }
                        //给堆排式按钮封起来
                        if (items.Count == 2) panel.AddStackedItems(items[0], items[1]);
                        else if (items.Count == 3) panel.AddStackedItems(items[0], items[1], items[2]);
                        else panel.AddItem(items[0]);
                    }
                    //给每个panel添加分隔
                    if (j < panels[i].Length - 1)
                        panel.AddSeparator();
                }
            }

            return Result.Succeeded;
        }

        private void LoadImageInfo()
        {
            var dir = @"E:\Projects\revit-addin-samples\ribbontabandbutton\bin\Debug";

            var imagePath = Path.Combine(dir, "Res", "Image");
            ImageList = Directory.GetFiles(imagePath, "*.png");

            var lgImagePath = Path.Combine(dir, "Res", "LargeImage");
            LargeImageList = Directory.GetFiles(lgImagePath, "*.png");

            var tpImagePath = Path.Combine(dir, "Res", "ToolTipImage");
            TooltipImageList = Directory.GetFiles(tpImagePath, "*.png");
        }

        private ImageSource GetIcon(string name, string[] source)
        {
            name = name.Replace("\r\n", "");

            var image = string.Empty;
            foreach (var src in source)
            {
                var fileName = Path.GetFileName(src).Replace(".png", "");
                if (fileName == name || name.StartsWith(fileName)) image = src;
            }

            if (string.IsNullOrEmpty(image))
            {
                image = source[0];
                //TaskDialog.Show("Error", $"未找到图片：{name}");
            }

            return new BitmapImage(new Uri(image));
        }
    }
}
