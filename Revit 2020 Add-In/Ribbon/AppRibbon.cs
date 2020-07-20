﻿using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using RibbonPanel = Autodesk.Revit.UI.RibbonPanel;

namespace Revit_2020_Add_In.Ribbon
{
    class AppRibbon
    {
        internal static void AddRibbonPanel(UIControlledApplication application)
        {
            //Tab Name that will display in Revit
            string TabName = "Torsion";

            //Create the Ribbon Tab
            application.CreateRibbonTab(TabName);

            //Get the assembly path to execute commands
            string AssemblyPath = Assembly.GetExecutingAssembly().Location;

            //Create an Image to display on the buttons
            BitmapImage ButtonImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/Button100x100.png"));
            BitmapImage FindReplaceImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/FindReplace100x100.png"));
            BitmapImage SheetCapitalizeImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/ToUpper100x100.png"));
            BitmapImage SheetSelectionImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/SheetSelection100x100.png"));
            BitmapImage SheetTitleblockKeyPlanImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/SheetTitleblockKeyPlan100x100.png"));
            BitmapImage ViewsViewLegendCopyImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/ViewLegendCopy100x100.png"));
            BitmapImage ViewsViewScheduleCopyImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/ViewScheduleCopy100x100.png"));
            BitmapImage ViewsLinkedViewsImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/LinkedView100x100.png"));
            BitmapImage ViewsLinkedViewsUpdateImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/LinkedViewUpdate100x100.png"));
            BitmapImage ViewsViewDeleteunplacedImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/ViewDeleteUnplaced100x100.png"));
            BitmapImage ToolsWarningsImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/Warning100x100.png"));
            BitmapImage ToolsElemOfCategoryImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/ComponentInfo100x100.png"));
            BitmapImage ToolsSheetLegendMultipleImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/SheetLegendToMultiple100x100.png"));
            BitmapImage ToolsSheetScheduleMultipleImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/SheetScheduleToMultiple100x100.png"));
            BitmapImage ToolsFamilyMultipleSharedParametersImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/MultipleSharedParameters100x100.png"));
            BitmapImage ViewsChangeViewReferenceImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/ChangeViewReference100x100.png"));
            BitmapImage MEPSpacesFromLinkedRoomsImage = new BitmapImage(new Uri("pack://application:,,,/Revit 2020 Add-In;component/Resources/CreateSpaces100x100.png"));

            //Create a Panel within the Tab
            RibbonPanel RibbonPanelOne = application.CreateRibbonPanel(TabName, "PANEL 1");
            RibbonPanel RibbonPanelSheets = application.CreateRibbonPanel(TabName, "Sheets");
            RibbonPanel RibbonPanelViews = application.CreateRibbonPanel(TabName, "Views");
            RibbonPanel RibbonPanelTools = application.CreateRibbonPanel(TabName, "Tools");
            RibbonPanel RibbonPanelMEP = application.CreateRibbonPanel(TabName, "MEP");
            RibbonPanel RibbonPanelSettings = application.CreateRibbonPanel(TabName, "Settings");

            //Create Push Button Data to create the Push button from
            PushButtonData pbdTestButton = new PushButtonData("cmdTestButton", "Button Name", AssemblyPath, "Revit_2020_Add_In.Commands.HelloWorld");

            PushButtonData pbdSheetSelection = new PushButtonData("cmdSheetSelection", "Sheet\nSelector", AssemblyPath, "Revit_2020_Add_In.Commands.SheetSelection");
            PushButtonData pbdSheetFindReplace = new PushButtonData("cmdSheetFindReplace", "Sheets\nFind Replace", AssemblyPath, "Revit_2020_Add_In.Commands.SheetFindReplace");
            PushButtonData pbdSheetNameCapitalize = new PushButtonData("cmdSheetNameCapitalize", "Capitalize\nName", AssemblyPath, "Revit_2020_Add_In.Commands.SheetNameCapitalize");
            PushButtonData pbdSheetTitleblockKeyPlan = new PushButtonData("cmdSheetTitleblockKeyPlan", "Key Plan\nVisibility", AssemblyPath, "Revit_2020_Add_In.Commands.SheetTitleblockKeyPlan");
            PushButtonData pbdSheetLegendToMultiple = new PushButtonData("cmdSheetLegendToMultiple", "Place\nLegends", AssemblyPath, "Revit_2020_Add_In.Commands.SheetLegendToMultiple")
            {
                //Use the PushButtonData property to determine when the ribbon button is enabled. In this case only when the active view is a Sheet
                AvailabilityClassName = "Revit_2020_Add-In.Ribbon.SheetCommandAvailability"
            };
            PushButtonData pbdSheetScheduleToMultiple = new PushButtonData("cmdSheetScheduleToMultiple", "Place\nSchedules", AssemblyPath, "Revit_2020_Add_In.Commands.SheetScheduleToMultiple")
            {
                //Use the PushButtonData property to determine when the ribbon button is enabled. In this case only when the active view is a Sheet
                AvailabilityClassName = "Revit_2020_Add-In.Ribbon.SheetCommandAvailability"
            };

            PushButtonData pbdViewsFindReplace = new PushButtonData("cmdViewsFindReplace", "Views\nFind Replace", AssemblyPath, "Revit_2020_Add_In.Commands.ViewFindReplace");
            PushButtonData pbdViewsViewLegendCopy = new PushButtonData("cmdToolsViewLegendCopy", "Copy\nLegends", AssemblyPath, "Revit_2020_Add_In.Commands.ViewLegendCopy");
            PushButtonData pbdViewsViewScheduleCopy = new PushButtonData("cmdToolsViewScheduleCopy", "Copy\nSchedules", AssemblyPath, "Revit_2020_Add_In.Commands.ViewScheduleCopy");
            PushButtonData pbdViewsLinkedViews = new PushButtonData("cmdToolsLinkedViews", "Linked\nViews", AssemblyPath, "Revit_2020_Add_In.Commands.LinkedViews");
            PushButtonData pbdViewsLinkedViewsUpdate = new PushButtonData("cmdToolsLinkedViewsUpdate", "Update\nViews", AssemblyPath, "Revit_2020_Add_In.Commands.LinkedViewUpdate");
            PushButtonData pbdViewsViewDeleteUnplaced = new PushButtonData("cmdToolsViewDeleteUnplaced", "Delete\nUnplaced", AssemblyPath, "Revit_2020_Add_In.Commands.ViewDeleteUnplacedViews");
            PushButtonData pbdViewsChangeViewReference = new PushButtonData("cmdViewsChangeViewReference", "Change\nReference", AssemblyPath, "Revit_2020_Add_In.Commands.ViewChangeViewReference");

            PushButtonData pbdToolsWarnings = new PushButtonData("cmdToolsWarnings", "Warnings", AssemblyPath, "Revit_2020_Add_In.Commands.Warnings");
            PushButtonData pbdToolsElemOfCategory = new PushButtonData("cmdToolsElemOfCategory", "Family Instances\nof Category", AssemblyPath, "Revit_2020_Add_In.Commands.ElementsOfCategory");
            PushButtonData pbdToolsFamilyMultipleSharedParameters = new PushButtonData("cmdToolsFamilyMultipleSharedParameters", "Shared\nParameters", AssemblyPath, "Revit_2020_Add_In.Commands.FamilyMultipleSharedParameters");

            PushButtonData pbdMEPSpacesFromLinkedRooms = new PushButtonData("cmdMEPSpacesFromLinkedRooms", "Create\nSpaces", AssemblyPath, "Revit_2020_Add_In.Commands.MEPSpacesFromRooms");

            //Create a Push Button from the Push Button Data
            PushButton pbTestButton = RibbonPanelOne.AddItem(pbdTestButton) as PushButton;

            PushButton pbSheetSelection = RibbonPanelSheets.AddItem(pbdSheetSelection) as PushButton;
            PushButton pbSheetNameCapitalize = RibbonPanelSheets.AddItem(pbdSheetNameCapitalize) as PushButton;
            PushButton pbSheetFindReplace = RibbonPanelSheets.AddItem(pbdSheetFindReplace) as PushButton;
            PushButton pbSheetTitleblockKeyPlan = RibbonPanelSheets.AddItem(pbdSheetTitleblockKeyPlan) as PushButton;

            PushButton pbViewsFindReplace = RibbonPanelViews.AddItem(pbdViewsFindReplace) as PushButton;
            PushButton pbViewsViewDeleteUnplaced = RibbonPanelViews.AddItem(pbdViewsViewDeleteUnplaced) as PushButton;

            PushButton pbToolsWarnings = RibbonPanelTools.AddItem(pbdToolsWarnings) as PushButton;
            PushButton pbToolsElemOfCategory = RibbonPanelTools.AddItem(pbdToolsElemOfCategory) as PushButton;
            PushButton pbToolsFamilyMultipleSharedParameters = RibbonPanelTools.AddItem(pbdToolsFamilyMultipleSharedParameters) as PushButton;

            PushButton pbMEPSpacesFromLinkedRooms = RibbonPanelMEP.AddItem(pbdMEPSpacesFromLinkedRooms) as PushButton;

            //If you are going to use PushButtonData objects for Pulldown or Split buttons, you have to set these properties BEFORE adding them
            pbdSheetLegendToMultiple.LargeImage = ToolsSheetLegendMultipleImage;
            pbdSheetScheduleToMultiple.LargeImage = ToolsSheetScheduleMultipleImage;
            pbdSheetLegendToMultiple.ToolTip = "Select a Legend Viewport to place on multiple sheets in the same location";
            pbdSheetScheduleToMultiple.ToolTip = "Select a Schedule Instance to place on multiple sheets int he same location";

            pbdViewsLinkedViews.LargeImage = ViewsLinkedViewsImage;
            pbdViewsLinkedViewsUpdate.LargeImage = ViewsLinkedViewsUpdateImage;
            pbdViewsViewLegendCopy.LargeImage = ViewsViewLegendCopyImage;
            pbdViewsViewScheduleCopy.LargeImage = ViewsViewScheduleCopyImage;
            pbdViewsLinkedViews.ToolTip = "Create Drafting Views based on Views in a Linked Model for reference";
            pbdViewsLinkedViewsUpdate.ToolTip = "Update Linked View information referenced from a Linked Model";
            pbdViewsLinkedViews.LongDescription = "Verify the current Revit Model has the following three parameters under Phasing paramter group and View category:\nLinked View - Yes/No\nLinked View GUID - Text\nLink Name - Text ";
            pbdViewsViewLegendCopy.ToolTip = "Copy one or more Legend Views from a Linked Document";
            pbdViewsViewLegendCopy.LongDescription = "Select the Linked Document from which you want to copy the Legend from. Then select from the available Legend views. Then press the Copy button to copy the Legends into the current Document.";
            pbdViewsViewScheduleCopy.ToolTip = "Copy one or more Schedules form a Linked Document";
            pbdViewsViewScheduleCopy.LongDescription = "Select the Linked Document from which you want to copy the Schedule from. Then select from the available Schedules. Then press the Copy button to copy the Schedules into the current Document.";

            //Pull Down buttons allow you to stack similar or grouped buttons into a stack that you can expand down and select
            PulldownButtonData pdbdCopyLegendSchedule = new PulldownButtonData("pullDownCopyLegendSchedule", "Copy\nLegend");
            PulldownButton pdbCopyLegendSchedule = RibbonPanelViews.AddItem(pdbdCopyLegendSchedule) as PulldownButton;
            pdbCopyLegendSchedule.LargeImage = ViewsViewLegendCopyImage;
            pdbCopyLegendSchedule.AddPushButton(pbdViewsViewLegendCopy);
            pdbCopyLegendSchedule.AddPushButton(pbdViewsViewScheduleCopy);

            PulldownButtonData pdbdLinkedViews = new PulldownButtonData("pullDownLinkView", "Link\nViews");
            PulldownButton pdbLinkedViews = RibbonPanelViews.AddItem(pdbdLinkedViews) as PulldownButton;
            pdbLinkedViews.LargeImage = ViewsLinkedViewsImage;
            pdbLinkedViews.AddPushButton(pbdViewsLinkedViews);
            pdbLinkedViews.AddPushButton(pbdViewsLinkedViewsUpdate);

            PushButton pbViewsChangeViewReference = RibbonPanelViews.AddItem(pbdViewsChangeViewReference) as PushButton;

            PulldownButtonData pdbdPlaceMultipleLegendSchedule = new PulldownButtonData("pulldownPlaceMultipleLegendSchedule", "Place\nLegends");
            PulldownButton pdbPlaceMultipleLegendSchedule = RibbonPanelSheets.AddItem(pdbdPlaceMultipleLegendSchedule) as PulldownButton;
            pdbPlaceMultipleLegendSchedule.LargeImage = ToolsSheetLegendMultipleImage;
            pdbPlaceMultipleLegendSchedule.AddPushButton(pbdSheetLegendToMultiple);
            pdbPlaceMultipleLegendSchedule.AddPushButton(pbdSheetScheduleToMultiple);

            RadioButtonGroupData rbgdUpdaters = new RadioButtonGroupData("UpdaterSettings");
            RadioButtonGroup rdoBtnGroup = RibbonPanelSettings.AddItem(rbgdUpdaters) as RadioButtonGroup;
            ToggleButtonData tbdUpdaterOn = new ToggleButtonData("cmdUpdaterOn", "Turn On\nDynamic\nUpdaters", AssemblyPath, "Revit_2020_Add_In.Settings.UpdatersOn");
            ToggleButtonData tbdUpdaterOff = new ToggleButtonData("cmdUpdaterOff", "Turn Off\nDynamic\nUpdaters", AssemblyPath, "Revit_2020_Add_In.Settings.UpdatersOff");

            tbdUpdaterOn.ToolTip = "Turn all Dynamic Model Updaters On";
            tbdUpdaterOff.ToolTip = "Turn all Dynamic Model Updaters Off";

            rdoBtnGroup.AddItem(tbdUpdaterOn);
            rdoBtnGroup.AddItem(tbdUpdaterOff);

            //Set Button Image
            pbTestButton.LargeImage = ButtonImage;

            pbSheetNameCapitalize.LargeImage = SheetCapitalizeImage;
            pbSheetFindReplace.LargeImage = FindReplaceImage;
            pbSheetSelection.LargeImage = SheetSelectionImage;
            pbSheetTitleblockKeyPlan.LargeImage = SheetTitleblockKeyPlanImage;

            pbViewsFindReplace.LargeImage = FindReplaceImage;
            pbViewsViewDeleteUnplaced.LargeImage = ViewsViewDeleteunplacedImage;
            pbViewsChangeViewReference.LargeImage = ViewsChangeViewReferenceImage;

            pbToolsWarnings.LargeImage = ToolsWarningsImage;
            pbToolsElemOfCategory.LargeImage = ToolsElemOfCategoryImage;
            pbToolsFamilyMultipleSharedParameters.LargeImage = ToolsFamilyMultipleSharedParametersImage;

            pbMEPSpacesFromLinkedRooms.LargeImage = MEPSpacesFromLinkedRoomsImage;

            //Set Button Tool Tips
            pbTestButton.ToolTip = "Tell the user what your button does here";
            pbSheetSelection.ToolTip = "Select from all of the Sheets in the Model";
            pbSheetFindReplace.ToolTip = "Find and Replace values in Sheet Name or Number";
            pbSheetNameCapitalize.ToolTip = "Capitalize the Name of all Sheets in the Model";
            pbSheetTitleblockKeyPlan.ToolTip = "Set Yes / No parameters of a Titleblock type based on search criteria of the Sheet Name or Sheet Number";

            pbViewsFindReplace.ToolTip = "Find and Replace values in View Name or Title on Sheet";
            pbViewsViewDeleteUnplaced.ToolTip = "Delete Views, View Templates, Schedules, and Legends that are not used";
            pbViewsChangeViewReference.ToolTip = "Change the Reference for all views that currently reference a different View";

            pbToolsWarnings.ToolTip = "Display and isolate Warnings in the Document";
            pbToolsElemOfCategory.ToolTip = "Get all Elements of selected Category";
            pbToolsFamilyMultipleSharedParameters.ToolTip = "Add the selected Shared Parameters in all Revit Families within the selected Directory";

            pbMEPSpacesFromLinkedRooms.ToolTip = "Create MEP Spaces for the Selected Rooms from a Linked Model";

            //Set Button Long description which is the text that flys out when you hover on a button longer
            pbTestButton.LongDescription = "Give the user more information about how they need to use the button features";
            pbSheetSelection.LongDescription = "The Sheet Selection Form can be used in multiple ways to allow the user to select one or multiple sheets in the project and perform additiona actions on the sheets returned.";
        }
    }
}
