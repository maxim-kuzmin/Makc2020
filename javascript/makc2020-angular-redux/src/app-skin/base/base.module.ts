// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {ModuleWithProviders, NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';

import {
  ButtonModule,
  CalendarModule,
  CheckboxModule,
  ColorPickerModule,
  DialogModule,
  DialogService,
  DropdownModule,
  FileUploadModule,
  InputSwitchModule,
  InputTextareaModule,
  InputTextModule,
  MessageService,
  MultiSelectModule,
  OverlayPanelModule,
  PaginatorModule,
  TabViewModule
} from 'primeng/primeng';
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import {TableModule} from 'primeng/table';
import {ToastModule} from 'primeng/toast';
import {DynamicDialogModule} from 'primeng/dynamicdialog';
import {AngularSplitModule} from '@app-skin/base/modules/split/angular-split.module';

/** Общее. Модуль. */
@NgModule({
  imports: [
    // Standard

    CommonModule,
    // FormsModule,
    ReactiveFormsModule,

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
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AppSkinBaseModule,
      providers: [
        DialogService,
        MessageService
      ]
    };
  }
}
