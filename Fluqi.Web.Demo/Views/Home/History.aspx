﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Fluqi.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Fluqi.Web.Demo.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">	
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">	
	<ul id="nav">
		<li><%=Html.ActionLink("Home", "Home", "Home")%></li>
	</ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="content-wrap">
	<section id="main">

	<div class="intro-box">
		<h1>History</h1>
		<p>
			We never expected <%=Html.ActionLink("Fluqi", "Home", "Home")%> to 
			<a href="<%=Url.Content("~/Content/asp-net-front-page.jpg")%>" 
				title="Fluqi on the asp.net home page, second only 'the guth', I can live with that :)">gather such interest so soon</a> 
			and it's fantastic that it has.
		</p>
		<p>
			We've noticed, and fixed, a couple of issues since the first release.  Here are the details of
			these changes, which may help you with migrating your existing code.
		</p>
	</div>

	<div class="slider-wrapper">
		<div id="" style="margin-left: 20px; margin-top: 20px;">
			<a href="<%=Url.Content("~/Content/asp-net-front-page.jpg")%>" title="Fluqi on the asp.net home page">
				<img src="<%=Url.Content("~/Content/asp-net-front-page-thumb.jpg")%>" alt="Fluqi on the asp.net home page" />
			</a>
		</div>
	</div>
	<div class="clearfix"></div>

	<h2>0.1.4</h2>
	<ul>
		<li>
		Accordion panels can now be configured fluently more easily with the addition of a <strong>Configure()</strong>
		method after the panel has been added.  Please see the <strong>Accordion_Can_Set_ID_On_Panel()</strong> test
		for an illustration.
		</li>
		<li>
		Accordion control incorrectly added <strong>ui-accordion-icons</strong> class even if icons weren't being displayed.
		</li>
		<li>
		The HTML mark-up used by the Accordion control can now be overriden, see 
		<strong>Accordion_Can_Override_Container_HTML_And_Header_HTML_And_Content_HTML_Tags</strong>
		test for an illustration.
		</li>
	</ul>

	<h2>0.1.3</h2>
	<ul>
		<li>
			Razor engine requires additional entries in the web.config to include the namespaces. These have now been added.
			Note this is only present in the <a href="http://nuget.org/packages/fluqi">nuget package</a>, however
			it is included in the 0.1.4 release on <a href="https://github.com/toepoke/Fluqi/downloads">github</a>.
		</li>
	</ul>

	<h2>0.2.0</h2>
	<ul>
		<li>Initial <a href="http://nuget.org/packages/fluqi">nuget package</a> released</li>
	</ul>

	<h2>0.1.0</h2>
	<ul>
		<li>Initial version</li>
	</ul>

	<a class="back-to-top" href="#header-wrap">Back to Top</a>
</section> <%--main--%>

</div> <%--content-wrap--%>

</asp:Content>
