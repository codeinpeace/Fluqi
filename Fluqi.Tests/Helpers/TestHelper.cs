﻿using System.Linq;
using Fluqi.Widget.jAccordion;
using Fluqi.Widget.jPushButton;
using Fluqi.Widget.jAutoComplete;
using Fluqi.Widget.jDatePicker;
using Fluqi.Widget.jDialog;
using Fluqi.Widget.jProgressBar;
using Fluqi.Widget.jSlider;
using Fluqi.Widget.jTab;
using Fluqi.Utilities.jCookie;
using Fluqi.Utilities.jPosition;
using System.IO;

namespace Fluqi.Tests.Helpers {

	public static class TestHelper {

		internal static Accordion SetupSimpleAccordionObject(TextWriter writer)
		{
			// nothing special, just create a simple dummy accordion helper as a starting point 
			// (saves having the same code everywhere!)
			Accordion acc = new Accordion(writer, "myAccordion");

			// leave the options to the calling test to set

			// define the test panels
			acc.Panels
				.Add("Pane #1")
				.Add("Pane #2")
				.Add("Pane #3")
			;

			return acc;
		}

		internal static void ForceRender(Accordion acc)
		{
			using (acc.RenderContainer()) {
				for (int n=0; n < acc.Panels.ToList().Count(); n++) {
					using (acc.Panels.RenderNextPane()) {
					} // pane
				} // for
			} // container
		}

		internal static AutoComplete SetupSimpleAutoCompleteObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			AutoComplete ac = new AutoComplete(writer, "ac", "['c++', 'java', 'php']");

			return ac;
		}

		internal static Fluqi.Widget.jPushButton.PushButton SetupSimpleButtonObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			Fluqi.Widget.jPushButton.PushButton btn = new Fluqi.Widget.jPushButton.PushButton(writer, "btn", "my button label");

			return btn;
		}

		internal static DatePicker SetupSimpleDatePickerObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			DatePicker dt = new DatePicker(writer, "dt");

			return dt;
		}

		internal static Dialog SetupSimpleDialogObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			Dialog dlg = new Dialog(writer, "myDlg");

			return dlg;
		}

		internal static void ForceRender(Dialog dlg)
		{
			using (dlg.RenderDialog()) {
			}
		}

		internal static Position SetupSimplePositionObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			Position ts = new Position(writer, "myPosition");

			return ts;
		}

		internal static void ForceRender(Position pos)
		{
			// Position doesn't have a render as there is no actual control 
			// we're interfacing with, it's just a front-end to the jQuery initialisation
			pos.Render();
		}

		internal static ProgressBar SetupSimpleProgressBarObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			ProgressBar pb = new ProgressBar(writer, "pb");

			return pb;
		}

		internal static void ForceRender(ProgressBar pb)
		{
			pb.Render();
		}

		internal static Slider SetupSimpleSliderObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			Slider ts = new Slider(writer, "mySlider");

			return ts;
		}

		internal static void ForceRender(Slider sldr)
		{
			sldr.Render();
		}

		internal static Tabs SetupSimpleTabObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			Tabs ts = new Tabs(writer, "myTabs");

			// define the test tabs
			ts.Panes
				.Add("tab1", "Tab 1")
				.Add("tab2", "Tab 2")
				.Add("tab3", "Tab 3")
			;

			return ts;
		}

		internal static void ForceRender(Tabs tabs)
		{
			using (tabs.RenderHeader()) {
				for (var tbNdx=0; tbNdx < tabs.Panes.ToDictionary().Count(); tbNdx++)
					using (tabs.Panes.RenderNextPane()) {}
			}
		}

		internal static Cookie SetupSimpleCookieObject(TextWriter writer) 
		{
			// nothing special, just create a simple dummy tab helper as a starting point 
			// (saves having the same code everywhere!)
			Cookie c = new Cookie(writer, "");

			return c;
		}

		internal static void ForceRender(Cookie c)
		{
			c.Render();
		}
	}
}
