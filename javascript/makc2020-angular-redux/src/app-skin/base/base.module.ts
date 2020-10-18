// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {ModuleWithProviders, NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {FullCalendarModule} from '@fullcalendar/angular'; // for FullCalendar!
import {
  ButtonModule,
  CalendarModule,
  CheckboxModule,
  ColorPickerModule,
  DialogModule,
  DialogService,
  DropdownModule,
  DynamicDialogModule,
  FileUploadModule,
  InputSwitchModule,
  InputTextareaModule,
  InputTextModule,
  MessageService,
  MultiSelectModule,
  OverlayPanelModule,
  PaginatorModule,
  ProgressSpinnerModule,
  TableModule,
  TabViewModule,
  ToastModule, ToolbarModule
} from 'primeng';
import {AngularSplitModule} from '@app-skin/base/modules/split/angular-split.module';

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
