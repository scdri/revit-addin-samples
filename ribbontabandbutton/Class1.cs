using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
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
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var assemblypath = Assembly.GetExecutingAssembly().Location;

            //define tabname and panels

            Dictionary<string, string[]> tabsandpanels = new Dictionary<string, string[]> {
                {"轴网/柱子",new[] { "楼层", "轴网创建", "轴网编辑", "轴号编辑", "柱子" } },
                { "墙/梁",new[] { "墙体生成", "墙体编辑", "阳台", "墙体贴面/拆分", "幕墙", "梁" } },
                {"门窗/楼板/面积",new[] { "门窗", "楼板", "屋顶", "女儿墙", "老虎墙" } },
                { "房间/面积", new[] { "标准库", "房间", "面积", "构件布置" } },
                { "楼梯/其他", new[] { "楼梯", "电梯/扶梯", "台阶/散水", "车库", "坡道" } },
                { "详图/标注", new[] { "剖面图/详图", "平、立面", "尺寸标注", "编辑标注", "符号标注" } }
            };

            
            for (int i = 0; i < tabsandpanels["轴网/柱子"].Length; i++)
            {
                Dictionary<string, string[]> items = new Dictionary<string, string[]> {
                { tabsandpanels["轴网/柱子"][i] ,new[]{ "楼层设置", "附加标高" } },
                { tabsandpanels["轴网/柱子"][i], new[]{ "直线轴网", "弧线轴网", "线生轴网", "三维轴网", "轴网标注" } },
                { tabsandpanels["轴网/柱子"][i], new[]{ "添加轴线", "删除轴线", "轴线合并", "轴线剪裁" } },
                { tabsandpanels["轴网/柱子"][i], new[]{ "文字设置", "全局轴号", "分区编号", "主辅转换", "轴号重排", "连续轴号", "轴号对齐", "轴号隐现" } },
                { tabsandpanels["轴网/柱子"][i], new[]{ "柱子插入", "角柱插入", "按层分柱", "柱齐墙边", "墙齐柱边" } }
            };
            }

            for (int i = 0; i < tabsandpanels["墙/梁"].Length; i++)
            {
                Dictionary<string, string[]> items = new Dictionary<string, string[]>
                {
                    { tabsandpanels["墙/梁"][i] ,new[]{ "绘制墙体", "轴网生墙", "线生墙" } },
                    { tabsandpanels["墙/梁"][i] ,new[]{ "外墙类型", "外墙朝向", "外墙对齐", "内墙对齐", "按层分墙", "墙体倒角", "墙体命名", "自动断墙", "墙体断开", "墙体连接", "拉伸" } },
                    { tabsandpanels["墙/梁"][i] ,new[]{ "绘制阳台", "编辑阳台" } },
                    { tabsandpanels["墙/梁"][i] ,new[]{ "添加保温", "外墙饰面", "内墙饰面", "柱子饰面", "多墙合并", "多墙修改", "墙体拆分" } },
                    { tabsandpanels["墙/梁"][i] ,new[]{ "幕墙绘制", "幕墙网格", "幕墙竖艇" } },
                    { tabsandpanels["墙/梁"][i] ,new[]{ "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" } },

                };
            }

            for (int i = 0; i < tabsandpanels["门窗/楼板/面积"].Length; i++)
            {
                Dictionary<string, string[]> items = new Dictionary<string, string[]>
                {
                    { tabsandpanels["门窗/楼板/面积"][i] ,new[]{ "插入门", "插入窗", "内外翻转","左右翻转","门窗编号","门窗图例",$"刷新{Environment.NewLine}门窗图例","门窗表",$"刷新{Environment.NewLine}门窗表", "拆分表格" } },
                    { tabsandpanels["门窗/楼板/面积"][i] ,new[]{ "生成楼板", "自动拆分", "楼板合并", "楼板升降", "板变斜板"} },
                    //
                    { tabsandpanels["门窗/楼板/面积"][i] ,new[]{ "绘制阳台", "编辑阳台" } },
                    { tabsandpanels["门窗/楼板/面积"][i] ,new[]{ "添加保温", "外墙饰面", "内墙饰面", "柱子饰面", "多墙合并", "多墙修改", "墙体拆分" } },
                    { tabsandpanels["门窗/楼板/面积"][i] ,new[]{ "幕墙绘制", "幕墙网格", "幕墙竖艇" } },
                    { tabsandpanels["门窗/楼板/面积"][i] ,new[]{ "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" } },

                };
            }






            //create panels of axiscolumn tab

            string[] axiscolumnpanelname = new string[] {  "楼层" , "轴网创建", "轴网编辑" , "轴号编辑" , "柱子" };
            var storey = createfuc.CreatePanel(application,axiscolumn, axiscolumnpanelname[0]);
            var axiscreate = createfuc.CreatePanel(application, axiscolumn, axiscolumnpanelname[1]);
            var axisedit = createfuc.CreatePanel(application, axiscolumn, axiscolumnpanelname[2]);
            var axisnumberedit = createfuc.CreatePanel(application, axiscolumn, axiscolumnpanelname[3]);
            var column = createfuc.CreatePanel(application, axiscolumn, axiscolumnpanelname[4]);

            //create buttons for panels of axiscolumn tab
            //add items and buttons for storey panel
            string[] buttonnameofaxiscolumn = new string[] { "楼层设置", "附加标高" };
            var storeyset = createfuc.AddItemToPanel(storey,"storeyset", buttonnameofaxiscolumn[0], assemblypath, "RevitDemos.HelloRevit");
            var additionalelevation = createfuc.AddItemToPanel(storey, "additionalelevation", buttonnameofaxiscolumn[1], assemblypath, "RevitDemos.HelloRevit");

            storey.AddSeparator();

            //add items and buttons for axiscreate panel
            string[] buttonnameofaxiscreate = new string[] { "直线轴网", "弧线轴网", "线生轴网", "三维轴网", "轴网标注"};
            var linegrid = createfuc.AddItemToPanel(axiscreate, "linegrid", buttonnameofaxiscreate[0], assemblypath, "RevitDemos.HelloRevit");
            var arcgrid = createfuc.AddItemToPanel(axiscreate, "arcgrid", buttonnameofaxiscreate[1], assemblypath, "RevitDemos.HelloRevit");
            var linetogrid = createfuc.AddItemToPanel(axiscreate, "linetogrid", buttonnameofaxiscreate[2], assemblypath, "RevitDemos.HelloRevit");
            var threeDgrid = createfuc.AddItemToPanel(axiscreate, "threeDgrid", buttonnameofaxiscreate[3], assemblypath, "RevitDemos.HelloRevit");
            var gridlabel = createfuc.AddItemToPanel(axiscreate, "gridlabel", buttonnameofaxiscreate[4], assemblypath, "RevitDemos.HelloRevit");

            axiscreate.AddSeparator();
 
            //add items and buttons for axisedit panel
            string[] buttonnameofaxisedit = new string[] { "添加轴线", "删除轴线", "轴线合并", "轴线剪裁"};
            var addaxis = createfuc.AddItemToPanel(axisedit, "addaxis", buttonnameofaxiscreate[0], assemblypath, "RevitDemos.HelloRevit");
            var deleteaxis = createfuc.AddItemToPanel(axisedit, "addaxis", buttonnameofaxiscreate[0], assemblypath, "RevitDemos.HelloRevit");
            var axismerge = createfuc.AddItemToPanel(axisedit, "axismerge", buttonnameofaxiscreate[0], assemblypath, "RevitDemos.HelloRevit");
            var axiscut = createfuc.AddItemToPanel(axisedit, "axiscut", buttonnameofaxiscreate[0], assemblypath, "RevitDemos.HelloRevit");

            axisedit.AddSeparator();


            //add items and buttons for axisnumberedit panel
            string[] buttonnameofaxisnumberedit = new string[] { "文字设置", "全局轴号", "分区编号", "主辅转换", "轴号重排", "连续轴号", "轴号对齐", "轴号隐现" };
            var textset = createfuc.AddItemToPanel(axisnumberedit, "textset", buttonnameofaxisnumberedit[0], assemblypath, "RevitDemos.HelloRevit");
            var gloaxisnum = createfuc.AddItemToPanel(axisnumberedit, "gloaxisnum", buttonnameofaxisnumberedit[1], assemblypath, "RevitDemos.HelloRevit");
            var parnum = createfuc.AddItemToPanel(axisnumberedit, "parnum", buttonnameofaxisnumberedit[2], assemblypath, "RevitDemos.HelloRevit");
            var mtoscon = createfuc.AddItemToPanel(axisnumberedit, "mtoscon", buttonnameofaxisnumberedit[3], assemblypath, "RevitDemos.HelloRevit");
            var axisnumreset = createfuc.AddItemToPanel(axisnumberedit, "axisnumreset", buttonnameofaxisnumberedit[4], assemblypath, "RevitDemos.HelloRevit");
            var continuousaxisnum = createfuc.AddItemToPanel(axisnumberedit, "continuousaxisnum", buttonnameofaxisnumberedit[5], assemblypath, "RevitDemos.HelloRevit");
            var axisnumalign = createfuc.AddItemToPanel(axisnumberedit, "axisnumalign", buttonnameofaxisnumberedit[6], assemblypath, "RevitDemos.HelloRevit");
            var axisloom = createfuc.AddItemToPanel(axisnumberedit, "axisloom", buttonnameofaxisnumberedit[7], assemblypath, "RevitDemos.HelloRevit");

            axisnumberedit.AddSeparator();

            //add items and button for column panel
            string[] buttonnameofcolumn = new string[] { "柱子插入", "角柱插入", "按层分柱", "柱齐墙边", "墙齐柱边"};
            var insertcolumn = createfuc.AddItemToPanel(column, "insertcolumn", buttonnameofaxisnumberedit[0], assemblypath, "RevitDemos.HelloRevit");
            var insertcorcolumn = createfuc.AddItemToPanel(column, "insertcorcolumn", buttonnameofaxisnumberedit[1], assemblypath, "RevitDemos.HelloRevit");
            var columnbylayer = createfuc.AddItemToPanel(column, "columnbylayer", buttonnameofaxisnumberedit[2], assemblypath, "RevitDemos.HelloRevit");
            var columntowallborder = createfuc.AddItemToPanel(column, "columntowallborder", buttonnameofaxisnumberedit[3], assemblypath, "RevitDemos.HelloRevit");
            var walltocolumnborder = createfuc.AddItemToPanel(column, "walltocolumnborder", buttonnameofaxisnumberedit[4], assemblypath, "RevitDemos.HelloRevit");

            column.AddSeparator();




            //create panels of wallbeam tab
            string[] wallbeampanelname = new string[] { "墙体生成", "墙体编辑", "阳台", "墙体贴面/拆分", "幕墙","梁" };
            var wallcreate = createfuc.CreatePanel(application, wallbeam, wallbeampanelname[0]);
            var walledit = createfuc.CreatePanel(application, wallbeam, wallbeampanelname[1]);
            var balcony = createfuc.CreatePanel(application, wallbeam, wallbeampanelname[2]);
            var wallveneerandsplit = createfuc.CreatePanel(application, wallbeam, wallbeampanelname[3]);
            var curtainwall = createfuc.CreatePanel(application, wallbeam, wallbeampanelname[4]);
            var beam = createfuc.CreatePanel(application, wallbeam, wallbeampanelname[5]);

            //create items and buttons for wallcreate panel
            string[] buttonnameofwallcreate = new string[] { "绘制墙体", "轴网生墙", "线生墙"};
            var drawwall = createfuc.AddItemToPanel(wallcreate, "drawwall", buttonnameofwallcreate[0], assemblypath, "RevitDemos.HelloRevit");
            var gridtowall = createfuc.AddStrackToPanel("gridtowall", buttonnameofwallcreate[1], assemblypath, "RevitDemos.HelloRevit");
            var linetowall = createfuc.AddStrackToPanel("linetowall", buttonnameofwallcreate[2], assemblypath, "RevitDemos.HelloRevit");

            wallcreate.AddStackedItems(gridtowall,linetowall);
            wallcreate.AddSeparator();

            //create items and buttons for walledit panel
            string[] bn_walledit = new string[] { "外墙类型", "外墙朝向", "外墙对齐", "内墙对齐", "按层分墙", "墙体倒角", "墙体命名","自动断墙","墙体断开","墙体连接","拉伸" };
            var ty_outw = createfuc.AddItemToPanel(walledit, "ty_outw", bn_walledit[0], assemblypath, "RevitDemos.HelloRevit");
            var dst_outw = createfuc.AddItemToPanel(walledit, "dst_outw", bn_walledit[1], assemblypath, "RevitDemos.HelloRevit");
            var align_outw = createfuc.AddItemToPanel(walledit, "align_outw", bn_walledit[2], assemblypath, "RevitDemos.HelloRevit");
            var align_inw = createfuc.AddItemToPanel(walledit, "align_inw", bn_walledit[3], assemblypath, "RevitDemos.HelloRevit");
            var layer_w = createfuc.AddItemToPanel(walledit, "layer_w", bn_walledit[4], assemblypath, "RevitDemos.HelloRevit");
            var chamfer_w = createfuc.AddItemToPanel(walledit, "chamfer_w", bn_walledit[5], assemblypath, "RevitDemos.HelloRevit");
            var name_w = createfuc.AddItemToPanel(walledit, "name_w", bn_walledit[6], assemblypath, "RevitDemos.HelloRevit");
            var autobreak_w = createfuc.AddItemToPanel(walledit, "autobreak_w", bn_walledit[7], assemblypath, "RevitDemos.HelloRevit");
            var break_w = createfuc.AddItemToPanel(walledit, "break_w", bn_walledit[8], assemblypath, "RevitDemos.HelloRevit");
            var connect_w = createfuc.AddItemToPanel(walledit, "connect_w", bn_walledit[9], assemblypath, "RevitDemos.HelloRevit");
            var strech_w = createfuc.AddItemToPanel(walledit, "strech_w", bn_walledit[10], assemblypath, "RevitDemos.HelloRevit");

            walledit.AddSeparator();


            //create items and buttons for balcony panel
            string[] bn_balcony = new string[] { "绘制阳台", "编辑阳台"};
            var draw_bal = createfuc.AddItemToPanel(balcony, "draw_bal", bn_balcony[0], assemblypath, "RevitDemos.HelloRevit");
            var edit_bal = createfuc.AddItemToPanel(balcony, "edit_bal", bn_balcony[1], assemblypath, "RevitDemos.HelloRevit");

            balcony.AddSeparator();

            //create items and buttons for wallveneerandsplit panel
            string[] bn_wallveneerandsplit = new string[] { "添加保温", "外墙饰面", "内墙饰面", "柱子饰面", "多墙合并", "多墙修改", "墙体拆分" };
            var add_heatpre = createfuc.AddItemToPanel(wallveneerandsplit, "add_heatpre", bn_wallveneerandsplit[0], assemblypath, "RevitDemos.HelloRevit");
            var veneer_outw = createfuc.AddItemToPanel(wallveneerandsplit, "veneer_outw", bn_wallveneerandsplit[1], assemblypath, "RevitDemos.HelloRevit");
            var veneer_inw = createfuc.AddItemToPanel(wallveneerandsplit, "veneer_inw", bn_wallveneerandsplit[2], assemblypath, "RevitDemos.HelloRevit");
            var veneer_column = createfuc.AddItemToPanel(wallveneerandsplit, "veneer_column", bn_wallveneerandsplit[3], assemblypath, "RevitDemos.HelloRevit");
            var combin_multiw = createfuc.AddItemToPanel(wallveneerandsplit, "combin_multiw", bn_wallveneerandsplit[4], assemblypath, "RevitDemos.HelloRevit");
            var modify_multiw = createfuc.AddItemToPanel(wallveneerandsplit, "modify_multiw", bn_wallveneerandsplit[5], assemblypath, "RevitDemos.HelloRevit");
            var split_multiw = createfuc.AddItemToPanel(wallveneerandsplit, "split_multiw", bn_wallveneerandsplit[6], assemblypath, "RevitDemos.HelloRevit");

            wallveneerandsplit.AddSeparator();


            //create items and buttons for curtainwall panel
            string[] bn_curtainwall = new string[] { "幕墙绘制", "幕墙网格", "幕墙竖艇" };
            var draw_curtainw = createfuc.AddItemToPanel(curtainwall, "draw_curtainw", bn_curtainwall[0], assemblypath, "RevitDemos.HelloRevit");
            var grid_curtainw = createfuc.AddItemToPanel(curtainwall, "grid_curtainw", bn_curtainwall[1], assemblypath, "RevitDemos.HelloRevit");
            var st_curtainw = createfuc.AddItemToPanel(curtainwall, "st_curtainw", bn_curtainwall[2], assemblypath, "RevitDemos.HelloRevit");

            curtainwall.AddSeparator();

            //create items and buttons for beam panel
            string[] bn_beam = new string[] { "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" };
            var draw_beam = createfuc.AddItemToPanel(beam, "draw_beam", bn_beam[0], assemblypath, "RevitDemos.HelloRevit");
            var draw_multibeam = createfuc.AddItemToPanel(beam, "draw_multibeam", bn_beam[1], assemblypath, "RevitDemos.HelloRevit");
            var beam_cant = createfuc.AddItemToPanel(beam, "beam_cant", bn_beam[2], assemblypath, "RevitDemos.HelloRevit");
            var ddkl = createfuc.AddItemToPanel(beam, "ddkl", bn_beam[3], assemblypath, "RevitDemos.HelloRevit");
            var beamjointcol = createfuc.AddItemToPanel(beam, "beamjointcol", bn_beam[4], assemblypath, "RevitDemos.HelloRevit");

            beam.AddSeparator();




            //create panels of doorwindowfloorslabroof tab
            string[] doorwindowfloorslabroofpanelname = new string[] { "门窗", "楼板", "屋顶", "女儿墙", "老虎墙" };
            var doorwindow = createfuc.CreatePanel(application, wallbeam, doorwindowfloorslabroofpanelname[0]); 
            var floors = createfuc.CreatePanel(application, wallbeam, doorwindowfloorslabroofpanelname[1]);
            var roof = createfuc.CreatePanel(application, wallbeam, doorwindowfloorslabroofpanelname[2]);
            var parapet = createfuc.CreatePanel(application, wallbeam, doorwindowfloorslabroofpanelname[3]);
            var tigerwall = createfuc.CreatePanel(application, wallbeam, doorwindowfloorslabroofpanelname[4]);

            //create items and buttons for doorwindow panel
            string[] bn_doorwindow = new string[] { "防火分区{Environment.NewLine}面积检测", "防火门{Environment.NewLine}等级检测", "梁变斜梁", "断多跨梁", "梁柱连接" };

            //create items and buttons for floors panel
            string[] bn_floors = new string[] { "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" };

            //create items and buttons for roof panel
            string[] bn_roof = new string[] { "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" };

            //create items and buttons for parapet panel
            string[] bn_parapet = new string[] { "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" };

            //create items and buttons for tigerwall panel
            string[] bn_tigerwall = new string[] { "绘制梁", "批量建梁", "梁变斜梁", "断多跨梁", "梁柱连接" };


            //create panels of roomarea tab
            string[] roomareapanelname = new string[] { "标准库", "房间", "面积", "构件布置" };
            var standardlibrary = createfuc.CreatePanel(application, wallbeam, roomareapanelname[0]);
            var rooms = createfuc.CreatePanel(application, wallbeam, roomareapanelname[1]);
            var area = createfuc.CreatePanel(application, wallbeam, roomareapanelname[2]);
            var componentlayout = createfuc.CreatePanel(application, wallbeam, roomareapanelname[3]);

            //create panels of stairselse tab
            string[] stairselsepanelname = new string[] { "楼梯", "电梯/扶梯", "台阶/散水", "车库", "坡道"};
            var stairs = createfuc.CreatePanel(application, wallbeam, stairselsepanelname[0]);
            var elevatorstaircase = createfuc.CreatePanel(application, wallbeam, stairselsepanelname[1]);
            var stepwater = createfuc.CreatePanel(application, wallbeam, stairselsepanelname[2]);
            var garage = createfuc.CreatePanel(application, wallbeam, stairselsepanelname[3]);
            var ramp = createfuc.CreatePanel(application, wallbeam, stairselsepanelname[4]);

            //create panels of detaillabel tab
            string[] detaillabelpanelname = new string[] { "剖面图/详图", "平、立面", "尺寸标注", "编辑标注", "符号标注" };
            var cutawaydetail = createfuc.CreatePanel(application, wallbeam, detaillabelpanelname[0]);
            var floorelevation = createfuc.CreatePanel(application, wallbeam, detaillabelpanelname[1]);
            var diemensionsmark = createfuc.CreatePanel(application, wallbeam, detaillabelpanelname[2]);
            var editmark = createfuc.CreatePanel(application, wallbeam, detaillabelpanelname[3]);
            var symbolmark = createfuc.CreatePanel(application, wallbeam, detaillabelpanelname[4]);



            return Result.Succeeded;

        }

        private ImageSource GetIcon()
        {
            throw new NotImplementedException();
        }


    }

    //create a class to add button and items to panels
    public class CreateFuc
    {
       
        public void CreateTabs(UIControlledApplication application, string tab)
        {
            application.CreateRibbonTab(tab);
        }
        
        public RibbonPanel CreatePanel( UIControlledApplication application, string tab, string panelname)
        {
            return application.CreateRibbonPanel(tab, panelname);
        }
        public PushButton AddItemToPanel(RibbonPanel ribbonpanel, string intername, string entername, string assemblypath, string path)
        {
            PushButton pushbutton= ribbonpanel.AddItem(new PushButtonData(intername, entername, assemblypath, path)) as PushButton;
            pushbutton.ToolTip = entername;
            pushbutton.Image = GetIcon();
            pushbutton.LargeImage = GetIcon();
            return pushbutton;
        }
        
        public PushButtonData AddStrackToPanel(string intername, string entername, string assemblypath, string path)
        {
            PushButtonData pushbutton = new PushButtonData(intername, entername, assemblypath, path);
            pushbutton.Image = GetIcon();
            pushbutton.LargeImage = GetIcon();
            return pushbutton;
        }


        private ImageSource GetIcon()
        {
            throw new NotImplementedException();
        }
    }
    
            
}
