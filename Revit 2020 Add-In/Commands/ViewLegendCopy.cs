﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;
using View = Autodesk.Revit.DB.View;


namespace Revit_2020_Add_In.Commands
{
    //This Attribute sets how transactions are handled. The Manual Transaction Mode allows us to control any 
    //transactions individually, but roll the entire function back if we return any Result other than Succeded
    [Transaction(TransactionMode.Manual)]
    //This class will call the View Legend Copy form copy legends from a Linked Document
    class ViewLegendCopy : IExternalCommand
    {
        //This line has to be here in order for the command to execute in the current Revit context
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get the Current Session / Project from Revit
            UIApplication uiapp = commandData.Application;

            //Get the Current Document from the Current Session
            Document doc = uiapp.ActiveUIDocument.Document;

            //Check to see if there is at least one Legend in the current Document because the Copy Utility needs one. We will also feed it to the form so we don't need another Filtered Element Collector
            //We are using Linq to filter the Filtered Element Collector for only Legends, and then to make sure it isn't a View Template
            if (new FilteredElementCollector(doc).OfClass(typeof(View)).Cast<View>().Where(x => x.ViewType == ViewType.Legend && !x.IsTemplate).FirstOrDefault() is View tempLegend)
            {
                //Create a new instance of the LinkViewCopyWPF form and pass the current document and Template Legend as variables
                WPF.LinkLegendCopyWPF form = new WPF.LinkLegendCopyWPF(doc, tempLegend);
                //Show the WPF Form for user input and checks to see if the DialogResult of the form is OK and resturn the correct result as needed.
                if (form.ShowDialog().Value)
                {
                    //Let Revit know it executed successfully. This is also how you can roll back the entire feature.
                    return Result.Succeeded;
                }
                else
                {
                    //Let Revit know the Execute method did not finish successfully. All modifications to the Document will be rolled back based on the TransactionMode
                    return Result.Cancelled;
                }
            }
            else
            {
                //Tell the user that there aren't any legends in the current document and to create one.
                TaskDialog.Show("Legend Missing", "The Document must contain at least one Legend.\nCreate a Legend in the Document and try again.");
                return Result.Failed;
            }
        }
    }
}