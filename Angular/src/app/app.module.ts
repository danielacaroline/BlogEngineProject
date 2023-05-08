import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from "@angular/common/http";
import { CategoryComponent } from './category/category.component';
import { ViewCategoriesComponent } from './category/view-categories/view-categories.component';
import { SharedService } from './shared.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PostComponent } from './post/post.component';
import { ViewPostsComponent } from './post/view-posts/view-posts.component';
import { AddEditPostComponent } from './post/add-edit-post/add-edit-post.component';
import { AddEditCategoryComponent } from './category/add-edit-category/add-edit-category.component';
import { FormsModule } from '@angular/forms';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap'
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';
import { BlogHomeComponent } from './blog-home/blog-home.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    ViewCategoriesComponent,
    PostComponent,
    ViewPostsComponent,
    AddEditPostComponent,
    AddEditCategoryComponent,
    ConfirmDeleteComponent,
    BlogHomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgbDropdownModule,
    NgbDatepickerModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
