import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogHomeComponent } from './blog-home/blog-home.component';
import { CategoryComponent } from './category/category.component';
import { ViewPostsComponent } from './post/view-posts/view-posts.component';
import { AppComponent } from './app.component';
import { AddEditPostComponent } from './post/add-edit-post/add-edit-post.component';

const routes: Routes = [
  { path:'home',  component: BlogHomeComponent},  
  { path:'post/:id', component: AddEditPostComponent},
  { path:'post', component: AddEditPostComponent},
  { path: '', pathMatch: 'full', redirectTo: 'home'}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
