---
title: WormCloud
---
# WormCloud Strain Management Software
### General Information
WormCloud is an open source project designed by [Delta Lyczak](https://github.com/lyczak) for the [Ursinus College](https://www.ursinus.edu/) [Biology Department](https://www.ursinus.edu/academics/biology/research/).  The goal was to develop a piece of software that could be used by Ursinus staff and students to track the various strains of C. elegans worms used by the department for research purposes.
### Organization and Interface
The application is organized around the storage and retrieval of strains (certain modified versions of a species) and samples (physical tubes containing a certain strain).  A navigation bar at the top of the screen provides a link to the strain list, sample list, sign-in, sign-out, and profile pages.  All of the lists feature dynamic, searchable, and sortable tables that automatically populate with details about their contents.  The links within the tables and buttons below the tables provide actions for creating, viewing, or editing strains and samples.  Additionally, samples of a given strain can be checked in and out on that strain's view page.  Objects can be deleted from their edit pages.
### Technical Details
This web application is written in C# and utilizes the ASP.NET MVC and API frameworks.  It is designed to be run on [Microsoft's IIS Web Server](https://www.iis.net/) with a database server to store the application data; I recommend [Microsoft's SQL Server](https://www.microsoft.com/en-us/sql-server).  The project is still under development, so please wait for a finished release before deploying.
