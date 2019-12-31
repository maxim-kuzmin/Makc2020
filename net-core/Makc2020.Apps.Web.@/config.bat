@echo off



set output_path=C:\Git\maxim-kuzmin\Makc2020\angular-6.1--asp.net-core-2.1

set project_name_prefix=Makc2020.Apps.Web.

set solution_file_name=Makc2020.sln



set script_project_name=%project_name_prefix%@

set script_project_path=%output_path%\%script_project_name%


set client_project_name=ClientApp

set client_folder_name=%project_name_prefix%%client_project_name%

set client_project_path=%output_path%\%client_folder_name%


set server_project_name=%project_name_prefix%ServerApp

set server_project_path=%output_path%\%server_project_name%



set publish_path=%output_path%\%project_name_prefix%Publish



set debug_site_port=8091

set debug_site_name=%debug_site_port%---Makc2020---debug

set debug_site_path=%publish_path%\Debug

set debug_apppool_name=%debug_site_name%


set release_site_port=8092

set release_site_name=%release_site_port%---Makc2020---release

set release_site_path=%publish_path%\Release

set release_apppool_name=%release_site_name%