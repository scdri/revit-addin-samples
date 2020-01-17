using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

using System.Windows.Media.Imaging;
using Autodesk.Revit.UI.Events;

namespace Ribbon
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Class1 : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        public Result OnStartup(UIControlledApplication application)
        {
            string tabName1 = @"楼层\轴网";
            string tabName2 = @"墙\梁";
            string tabName3 = @"门窗\楼板\屋顶";
            string tabName4 = @"房间\面积";
            string tabName5 = @"楼梯\其它";
            string tabName6 = @"详图\标注";

            Dictionary<string, string[]> tab1 = new Dictionary<string, string[]> {
                                    { "楼层" ,new []{ "楼层设置","附加标高" } },
                                    { "轴网创建", new []{ "直线轴网", "弧线轴网", "线生轴网", "三维轴网", "轴网标注" } },
                                    { "轴线编辑", new []{ "添加轴线", "删除轴线", "轴线合并", "轴线剪裁" } },
                                    { "轴号编辑", new []{ "文字设置", "全局轴号", "分区编号", "主辅转换", "轴号重排", "连续轴号", "轴号对齐", "轴号隐现" } },
                                    { "柱子", new []{ "柱子插入", "按层分柱", "柱齐墙边", "墙齐柱边" } } };
            Dictionary<string, string[]> tab2 = new Dictionary<string, string[]> {
                                    { "墙体生成", new[] {"绘制墙体","轴网生墙", "线生墙" } },
                                    { "墙体编辑", new[] { "外墙类型","外墙朝向","外墙对齐","内墙对齐","按层分墙","墙体倒角","墙体命名","自动断墙","墙体断开","墙体连接","拉伸"}},
                                    { "阳台", new[]{ "绘制阳台","编辑阳台"} },
                                    { @"墙体贴面\拆分",new[]{ "添加保温","外墙饰面","内墙饰面","柱子饰面","多墙合并","多墙修改","墙体拆分"} },
                                    { "幕墙", new[] { "幕墙绘制", "幕墙网格", "幕墙竖挺" }},
                                    { "梁", new[] {"绘制梁","批量建梁","梁变斜梁","断多跨梁","梁柱连接" }} };
            Dictionary<string, string[]> tab3 = new Dictionary<string, string[]> {
                                    { "门窗", new[]{"插入门","插入窗","内外翻转","左右翻转","门窗编号","门窗图例","刷新门窗图例","门窗表","刷新门窗表","拆分表格" } },
                                    { "楼板", new[]{"生成楼板","自动拆分","楼板合并","楼板升降","板变斜板" } },
                                    { "屋顶", new[]{"拉伸屋顶","面屋顶" } },
                                    { "女儿墙", new[]{"自动女儿墙","手动女儿墙","编辑女儿墙" } },
                                    { "老虎窗", new[]{"老虎窗" } }};
            Dictionary<string, string[]> tab4 = new Dictionary<string, string[]> {
                                    { "标准库",new[]{"库管理","户型分发","户型拼接" } },
                                    { "房间",new[]{"房间设置","房间编号","批量编号","房间分隔","标记居中","构件添加房间属性","三维标记","生成房间","房间标记","房间装饰","名称替换","房间做法" } },
                                    { "面积",new[]{"面积显隐","建筑面积","套内面积","防火分区","防火分区缩略图","防火分区合并","面积统计","住宅面积表", "其它面积表", "颜色方案" } },
                                    { "构建布置",new[]{ "家具布置","卫浴布置"} } };
            Dictionary<string, string[]> tab5 = new Dictionary<string, string[]> {
                                    { "楼梯",new[]{"双跑楼梯","多跑楼梯","连续直段","剪刀楼梯","钢梯","双分平行","双分转角","交叉楼梯","直段楼梯","弧形楼梯","双分三跑","三角楼梯","矩形转角","梯梁合并","编辑楼梯", "楼梯拆分", "楼梯合并","面层显隐"} },
                                    { @"电梯\扶梯",new[]{"电梯布置","删除电梯","自动扶梯","扶梯图例"} },
                                    { @"台阶\散水",new[]{ "绘制台阶","创建散水"} },
                                    { "车库",new[]{ "汽车坡道","编辑汽车坡道","汽车坡道展开图","车道线绘制","方向键头放置","自动布车","车位编号","车位编号删除","车位统计"} },
                                    { "坡道",new[]{ "入门坡道","无障碍坡道","编辑无障碍坡道"} } };
            Dictionary<string, string[]> tab6 = new Dictionary<string, string[]> {
                                    { @"剖面图\详图", new[]{ "填充设置","楼梯平面详图","楼梯剖面详图","楼梯净高标注","楼梯净高标注删除","电梯平面详图","电梯剖面详图","剖面图","墙身详图"} },
                                    { "平、立面", new[]{ "一键平面","一键立面","立面轮廓创建","编辑立面轮廓创建","删除立面轮廓创建"} },
                                    { "尺寸标注", new[]{ "标注设置","门窗标注","墙厚标注","两点标注","内门标注","快速标注","层间标注","立面门窗标注","轴网标注","对齐标注","线性标注","角度标注","径向标注"} },
                                    { "编辑标注", new[]{ "隐藏标注","连接尺寸","打断尺寸","合并区间","位置取齐","线长取齐"} },
                                    { "符号标注", new[]{ "标高标注","坡度标注","引线标注","索引标注","箭头标注","做法标注","加折断线","图名标注"} } };
           
            application.CreateRibbonTab(tabName1);
            Dictionary<string, string[]>.KeyCollection panels1 = tab1.Keys;
            foreach (string panelName in panels1)
            {
                RibbonPanel panel = application.CreateRibbonPanel(tabName1, panelName);
                foreach (string button in tab1[panelName])
                {
                    AddPushButton(panel, button);
                }
            }

            application.CreateRibbonTab(tabName2);
            Dictionary<string, string[]>.KeyCollection panels2 = tab2.Keys;
            foreach (string panelName in panels2)
            {
                RibbonPanel panel = application.CreateRibbonPanel(tabName2, panelName);
                if (string.Compare(panelName, "墙体生成") == 0)
                {
                    AddPushButton(panel, "绘制墙体");
                    AddStackedButton(panel, new[] { "轴网生墙", "线生墙" });
                }else if (string.Compare(panelName, "幕墙") == 0)
                {
                    AddStackedButton(panel, tab2[panelName]);
                }
                else{
                    foreach (string button in tab2[panelName]) {
                        AddPushButton(panel, button);
                    }
                }
            }

            application.CreateRibbonTab(tabName3);
            Dictionary<string, string[]>.KeyCollection panels3 = tab3.Keys;
            foreach (string panelName in panels3)
            {
                RibbonPanel panel = application.CreateRibbonPanel(tabName3, panelName);
                foreach (string button in tab3[panelName])
                {
                    AddPushButton(panel, button);
                }
            }

            application.CreateRibbonTab(tabName4);
            Dictionary<string, string[]>.KeyCollection panels4 = tab4.Keys;
            foreach (string panelName in panels4)
            {
                RibbonPanel panel = application.CreateRibbonPanel(tabName4, panelName);
                foreach (string button in tab4[panelName])
                {
                    AddPushButton(panel, button);
                }
            }

            application.CreateRibbonTab(tabName5);
            Dictionary<string, string[]>.KeyCollection panels5 = tab5.Keys;
            foreach (string panelName in panels5)
            {
                RibbonPanel panel = application.CreateRibbonPanel(tabName5, panelName);
                int i = 0;
                if (string.Compare(panelName, "楼梯") == 0)
                {
                    for (i = 0;i < 5; i++)
                    {
                        AddPushButton(panel, tab5[panelName][i]);
                    }
                    for (i = 5;i < 14;i = i + 3)
                    {
                        AddStackedButton(panel, new[] { tab5[panelName][i], tab5[panelName][i + 1], tab5[panelName][i + 2] });
                    }
                    AddPushButton(panel, tab5[panelName][14]);
                    AddStackedButton(panel, new[] { tab5[panelName][15], tab5[panelName][16], tab5[panelName][17] });
                }
                else
                {
                    foreach (string button in tab5[panelName])
                    {
                        AddPushButton(panel, button);
                    }

                }
            }

            application.CreateRibbonTab(tabName6);

            return Result.Succeeded;
        }
        public void AddPushButton(RibbonPanel panel, string button)
        {
            PushButtonData pbd = new PushButtonData(string.Concat(button, button), button, @"D:\RevitDevelop\Lab1PlaceGroup\Lab1PlaceGroup\bin\Debug\Lab1PlaceGroup.dll", "Lab1PlaceGroup.Class1");
            if (string.Compare(button, "刷新门窗图例")==0)
            {
                pbd.LargeImage = new BitmapImage(new Uri(string.Concat(@"D:\RevitDevelop\Res\LargeImage\刷新门窗.png")));
            }else if (string.Compare(button, "名称替换") == 0)
            {
                pbd.LargeImage = new BitmapImage(new Uri(string.Concat(@"D:\RevitDevelop\Res\LargeImage\房间名称查找替换.png"))); 
            }else if(string.Compare(button, "面层显隐") == 0)
            {
                pbd.LargeImage = new BitmapImage(new Uri(string.Concat(@"D:\RevitDevelop\Res\LargeImage\面层显示隐藏.png")));
            }
            else
            {
                pbd.LargeImage = new BitmapImage(new Uri(string.Concat(@"D:\RevitDevelop\Res\LargeImage\", button, ".png")));
            }
            
            PushButton pb = panel.AddItem(pbd) as PushButton;
        }
        public void AddStackedButton(RibbonPanel panel, string[] button)
        {
            List<PushButtonData> pbds = new List<PushButtonData>();
            foreach (string b in button)
            {
                PushButtonData pbd = new PushButtonData(string.Concat(b, b), b, @"D:\RevitDevelop\Lab1PlaceGroup\Lab1PlaceGroup\bin\Debug\Lab1PlaceGroup.dll", "Lab1PlaceGroup.Class1");
                pbd.Image = new BitmapImage(new Uri(string.Concat(@"D:\RevitDevelop\Res\Image\", b, ".png")));
                pbds.Add(pbd);
            }
            if (pbds.Count == 2)
            {
                panel.AddStackedItems(pbds[0], pbds[1]);
            }else if(pbds.Count == 3)
            {
                panel.AddStackedItems(pbds[0], pbds[1], pbds[2]);
            }
        }

    }
}
