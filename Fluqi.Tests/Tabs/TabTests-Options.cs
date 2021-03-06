﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fluqi.Widget.jTab;
using System.Web;
using System.Web.Routing;
using Fluqi.Tests.Mocks;
using Fluqi.Tests;
using Fluqi.Tests.Helpers;

namespace Fluqi.Tests
{
	[TestClass]
	public partial class Tab_Options_Tests
	{

		[TestMethod]
		public void Ensure_Multiple_Options_Are_Added_To_Script_Definition_Correctly()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetIdPrefix("my-tabs-prefix")
					.SetCollapsible(true)
				.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);

			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({collapsible: true,idPrefix: \"my-tabs-prefix\"})" + 
					";});" + 
				"</script>";

			Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Tab_Marked_As_Selected_Has_Correct_Styling_And_JavaScript()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Rendering
					.Compress()
					.ShowCSS()
			;

			// Set 3rd tab as selected
			tabs.Panes.ToDictionary()["tab3"].IsSelected = true;

			TestHelper.ForceRender(tabs);

			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			// Check styling is correct
			Assert.IsTrue(html.Contains("<li class=\"ui-state-default ui-corner-top ui-tabs-selected ui-state-active\">") );
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({selected: 2})" + 
					";});" + 
				"</script>";

			// Check script output
			Assert.IsTrue(html.Contains(expected));
		}
	
		[TestMethod]
		public void Ensure_AjaxOptions_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetAjaxOptions("{ async: false, password: \"xyz\" }")
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);

			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({ajaxOptions: { async: false, password: \"xyz\" }})" + 
					";});" + 
				"</script>";

			Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Cache_Option_Is_Added_To_Script_Definition_When_True()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetCache(true)
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);

			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({cache: true})" + 
					";});" + 
				"</script>";

			Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Collapsible_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetCollapsible(true)
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);

			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({collapsible: true})" + 
					";});" + 
				"</script>";

			Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Cookie_Option_With_Number_Expiry_Is_Added_To_Script_Definition()
		{
		  // Arrange
		  var resp = new MockWriter();
		  Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

		  // only testing raw output
		  tabs
		    .Rendering
		      .Compress()
		  ;

		  // Position needs to be set a little bit differently as it's an set of options
		  // in its own right
		  tabs
		    .Options
		      .Cookie
		        .SetExpiry(8)
		      .Finish()
				.Finish()
		  ;

		  TestHelper.ForceRender(tabs);

		  // Act - Force output we'd see on the web page
		  string html = resp.Output.ToString();

		  // Assert
		  string expected = 
		    "<script type=\"text/javascript\">" + 
		      "$(document).ready( function() {" + 
		        "$(\"#myTabs\").tabs({cookie: {expires: 8}})" + 
		      ";});" + 
		    "</script>";

		  Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Cookie_Option_With_Path_Expiry_Is_Added_To_Script_Definition()
		{
		  // Arrange
		  var resp = new MockWriter();
		  Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

		  // only testing raw output
		  tabs
		    .Rendering
		      .Compress()
		  ;

		  // Position needs to be set a little bit differently as it's an set of options
		  // in its own right
		  tabs
		    .Options
		      .Cookie
		        .SetPath("/")
		      .Finish()
				.Finish()
		  ;

		  TestHelper.ForceRender(tabs);

		  // Act - Force output we'd see on the web page
		  string html = resp.Output.ToString();

		  // Assert
		  string expected = 
		    "<script type=\"text/javascript\">" + 
		      "$(document).ready( function() {" + 
		        "$(\"#myTabs\").tabs({cookie: {path: '/'}})" + 
		      ";});" + 
		    "</script>";

		  Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Cookie_Option_With_Domain_Is_Added_To_Script_Definition()
		{
		  // Arrange
		  var resp = new MockWriter();
		  Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

		  // only testing raw output
		  tabs
		    .Rendering
		      .Compress()
		  ;

		  // Position needs to be set a little bit differently as it's an set of options
		  // in its own right
		  tabs
		    .Options
		      .Cookie
		        .SetDomain("blog.toepoke.co.uk")
		      .Finish()
				.Finish()
		  ;

		  TestHelper.ForceRender(tabs);

		  // Act - Force output we'd see on the web page
		  string html = resp.Output.ToString();

		  // Assert
		  string expected = 
		    "<script type=\"text/javascript\">" + 
		      "$(document).ready( function() {" + 
		        "$(\"#myTabs\").tabs({cookie: {domain: 'blog.toepoke.co.uk'}})" + 
		      ";});" + 
		    "</script>";

		  Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Cookie_Option_With_Secure_Setting_As_True_Is_Added_To_Script_Definition()
		{
		  // Arrange
		  var resp = new MockWriter();
		  Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

		  // only testing raw output
		  tabs
		    .Rendering
		      .Compress()
		  ;

		  // Position needs to be set a little bit differently as it's an set of options
		  // in its own right
		  tabs
		    .Options
		      .Cookie
		        .SetSecure(true)
		      .Finish()
				.Finish()
		  ;

		  TestHelper.ForceRender(tabs);

		  // Act - Force output we'd see on the web page
		  string html = resp.Output.ToString();

		  // Assert
		  string expected = 
		    "<script type=\"text/javascript\">" + 
		      "$(document).ready( function() {" + 
		        "$(\"#myTabs\").tabs({cookie: {secure: true}})" + 
		      ";});" + 
		    "</script>";

		  Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Cookie_Option_With_Secure_Setting_As_Default_Is_Added_To_Script_Definition()
		{
		  // Arrange
		  var resp = new MockWriter();
		  Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

		  // only testing raw output
		  tabs
		    .Rendering
		      .Compress()
		  ;

		  // Position needs to be set a little bit differently as it's an set of options
		  // in its own right
		  tabs
		    .Options
		      .Cookie
		        .SetSecure(false)
		      .Finish()
				.Finish()
		  ;

		  TestHelper.ForceRender(tabs);

		  // Act - Force output we'd see on the web page
		  string html = resp.Output.ToString();

		  // Assert
		  string expected = 
		    "<script type=\"text/javascript\">" + 
		      "$(document).ready( function() {" + 
		        "$(\"#myTabs\").tabs()" + 
		      ";});" + 
		    "</script>";

		  Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Cookie_Option_With_Mixed_Options_As_True_Is_Added_To_Script_Definition()
		{
		  // Arrange
		  var resp = new MockWriter();
		  Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

		  // only testing raw output
		  tabs
		    .Rendering
		      .Compress()
		  ;

		  // Position needs to be set a little bit differently as it's an set of options
		  // in its own right
		  tabs
		    .Options
		      .Cookie
						.SetExpiry(9)
						.SetDomain("blog.toepoke.co.uk")
		      .Finish()
				.Finish()
		  ;

		  TestHelper.ForceRender(tabs);

		  // Act - Force output we'd see on the web page
		  string html = resp.Output.ToString();

		  // Assert
		  string expected = 
		    "<script type=\"text/javascript\">" + 
		      "$(document).ready( function() {" + 
		        "$(\"#myTabs\").tabs({cookie: {expires: 9,domain: 'blog.toepoke.co.uk'}})" + 
		      ";});" + 
		    "</script>";

		  Assert.IsTrue(html.Contains(expected));
		}

		[TestMethod]
		public void Ensure_Disabled_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetDisabled(true)
				.Finish()
				.Rendering
					.Compress();
	
			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert: Note the disabled by flag doesn't work in jQuery UI due to a bug, so we set each tab individually instead
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({disabled: [ 0, 1, 2 ]})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_DisabledArray_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetDisabled(new List<int>{2, 3})
				.Finish()
				.Rendering
					.Compress();
	
			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({disabled: [ 2, 3 ]})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_DisabledParamArray_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetDisabled(2, 3)
					.Finish()
				.Rendering
					.Compress();
	
			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({disabled: [ 2, 3 ]})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_Effects_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetEffect("{ opacity: 'toggle' }")
				.Finish()
				.Rendering
					.Compress();
			
			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({fx: { opacity: 'toggle' }})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		

		[TestMethod]
		public void Ensure_Event_Option_By_Enum_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetEvent(Core.BrowserEvent.eBrowserEvent.MouseOver)
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({event: \"mouseover\"})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_Event_Option_By_String_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetEvent("mouseover")
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({event: \"mouseover\"})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_Event_Default_Option_Is_Not_Rendered()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetEvent(Options.DEFAULT_EVENT)
					.Finish()
				.Rendering
				.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs()" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_IdPrefix_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetIdPrefix("ui-tabs-primary")
				.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({idPrefix: \"ui-tabs-primary\"})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_IdPrefix_Default_Option_Is_Not_Rendered()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options	
					.SetIdPrefix(Options.DEFAULT_ID_PREFIX)
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs()" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_PanelTemplate_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetPanelTemplate("<li></li>")
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({panelTemplate: \"<li></li>\"})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_PanelTemplate_Default_Option_Is_Not_Rendered()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetPanelTemplate(Options.DEFAULT_PANEL_TEMPLATE)
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs()" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_Spinner_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetSpinner("Retrieving data...")
				.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({spinner: \"Retrieving data...\"})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_Spinner_Default_Option_Is_Not_Rendered()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetSpinner(Options.DEFAULT_SPINNER)
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs()" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}		


		[TestMethod]
		public void Ensure_TabTemplate_Option_Is_Added_To_Script_Definition()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetTabTemplate("<div><a href=\"#{href}\"><span>#{label}</span></a></div>")
				.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs({tabTemplate: \"<div><a href=\"#{href}\"><span>#{label}</span></a></div>\"})" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}


		[TestMethod]
		public void Ensure_TabTemplate_Default_Option_Is_Not_Rendered()
		{
			// Arrange
			var resp = new MockWriter();
			Tabs tabs = TestHelper.SetupSimpleTabObject(resp);

			// only testing raw output
			tabs
				.Options
					.SetTabTemplate(Options.DEFAULT_TAB_TEMPLATE)
					.Finish()
				.Rendering
					.Compress();

			TestHelper.ForceRender(tabs);
			
			// Act - Force output we'd see on the web page
			string html = resp.Output.ToString();

			// Assert
			string expected = 
				"<script type=\"text/javascript\">" + 
					"$(document).ready( function() {" + 
						"$(\"#myTabs\").tabs()" + 
					";});" + 
				"</script>";
			Assert.IsTrue(html.Contains(expected));
		}

	} // jTab_Tests

} // ns
