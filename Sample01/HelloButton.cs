using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Sample01
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.ReadOnly)]
    public class HelloButton : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Hello", "Hellow World!");
            return Result.Succeeded;
        }
    }
}
