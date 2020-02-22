// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {ModuleWithProviders, NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {AngularSplitModule} from '@app-skin/base/modules/split/angular-split.module';
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
  ToastModule
} from 'primeng';

/** Общее. Модуль. */
@NgModule({
  imports: [
    // Standard

    CommonModule,
    // FormsModule,
    ReactiveFormsModule,

    // External

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
    TabViewModule,
    TableModule,
    ToastModule,

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
