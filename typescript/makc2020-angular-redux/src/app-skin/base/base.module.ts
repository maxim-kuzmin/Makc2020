// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {ModuleWithProviders, NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {FullCalendarModule} from '@fullcalendar/angular'; // for FullCalendar!
import {ButtonModule} from 'primeng/button';
import {AngularSplitModule} from '@app-skin/base/modules/split/angular-split.module';
import {CalendarModule} from 'primeng/calendar';
import {DialogModule} from 'primeng/dialog';
import {DropdownModule} from 'primeng/dropdown';
import {ColorPickerModule} from 'primeng/colorpicker';
import {CheckboxModule} from 'primeng/checkbox';
import {DialogService, DynamicDialogModule} from 'primeng/dynamicdialog';
import {FileUploadModule} from 'primeng/fileupload';
import {InputSwitchModule} from 'primeng/inputswitch';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {InputTextModule} from 'primeng/inputtext';
import {MultiSelectModule} from 'primeng/multiselect';
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import {OverlayPanelModule} from 'primeng/overlaypanel';
import {PaginatorModule} from 'primeng/paginator';
import {TableModule} from 'primeng/table';
import {TabViewModule} from 'primeng/tabview';
import {ToastModule} from 'primeng/toast';
import {ToolbarModule} from 'primeng/toolbar';
import {MessageService} from 'primeng/api';

/** Общее. Модуль. */
@NgModule({
  imports: [
    // Standard

    CommonModule,
    // FormsModule,
    ReactiveFormsModule,

    // External

    // @fullcalendar/angular
    FullCalendarModule,
    // primeng
    ButtonModule,
    CalendarModule,
    CheckboxModule,
    ColorPickerModule,
    DialogModule,
    DropdownModule,
    DynamicDialogModule,
    FileUploadModule,
    InputSwitchModule,
    InputTextareaModule,
    InputTextModule,
    MultiSelectModule,
    OverlayPanelModule,
    PaginatorModule,
    ProgressSpinnerModule,
    TableModule,
    TabViewModule,
    ToastModule,
    ToolbarModule,

    // Internal

    AngularSplitModule
  ],
  exports: [
    // Standard

    CommonModule,
    // FormsModule,
    ReactiveFormsModule,
    RouterModule,

    // External

    // @fullcalendar/angular
    FullCalendarModule,
    // primeng/dynamicdialog
    DynamicDialogModule,
    // primeng/primeng
    ButtonModule,
    CalendarModule,
    CheckboxModule,
    ColorPickerModule,
    DialogModule,
    DropdownModule,
    FileUploadModule,
    InputSwitchModule,
    InputTextareaModule,
    InputTextModule,
    MultiSelectModule,
    OverlayPanelModule,
    PaginatorModule,
    TabViewModule,
    // primeng/progressspinner
    ProgressSpinnerModule,
    // primeng/table
    TableModule,
    // primeng/toast
    ToastModule,
    ToolbarModule,

    // Internal

    AngularSplitModule
  ]
})
export class AppSkinBaseModule {
  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders<AppSkinBaseModule> {
    return {
      ngModule: AppSkinBaseModule,
      providers: [
        DialogService,
        MessageService
      ]
    };
  }
}
