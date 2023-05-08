import { Component, OnInit, ElementRef, AfterViewInit, ViewChild } from '@angular/core';
import { SharedService } from "src/app/shared.service";
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl  } from '@angular/forms';

@Component({
  selector: 'app-add-edit-post',
  templateUrl: './add-edit-post.component.html',
  styleUrls: ['./add-edit-post.component.scss']
})
export class AddEditPostComponent implements OnInit, AfterViewInit {

  @ViewChild('titleField') titleField!: ElementRef<HTMLInputElement>;

  titlePage: any = "Blog - Add Post";
  posts:any=[];
  post:any;
  id:any = 0;
  title_view: any;
  publicationDate_view:any;
  category_view:any;
  idCategory_view:any;
  content_view:any;
  idCategory:any = 0 ;
  categories:any =[];
  title!: FormControl;
  publicationDate!: FormControl;
  content!: FormControl;  
  category!: FormControl;
  postForm!: FormGroup;

  isFormSubmitted:boolean = false;

  constructor(private service: SharedService, private route: ActivatedRoute, private router: Router, public fb: FormBuilder){

    this.route.paramMap.subscribe(params => {
      this.getPostById(params.get('id'));
      });

    this.getCategories();
  }

  ngOnInit() {
    this.createFormControls();
    this.createForm();

    if(this.post != undefined){
      this.title_view = this.post.title;
      this.content_view = this.post.content;
      this.idCategory = this.post.idCategory;
      this.titlePage =  "Blog - Edit Post";

      this.getCategoryPost();
      this.publicationDate_view = new NgbDate(
            new Date(this.post.publicationDate).getFullYear(),
            new Date(this.post.publicationDate).getMonth() + 1,
            new Date(this.post.publicationDate).getDate()
      )  
    }
  }

  ngAfterViewInit() {
    this.titleField.nativeElement.focus();
  }

  createFormControls() {
    this.title = new FormControl('', [ Validators.required]);
    this.publicationDate = new FormControl('', Validators.required);
    this.category = new FormControl('', Validators.required);
    this.content = new FormControl('', [ Validators.required]);
  }

  createForm() {
    this.postForm = new FormGroup({
      title: this.title,
      publicationDate: this.publicationDate,
      category: this.category,
      content: this.content
    });
  } 

  getCategories(){
    this.service.currentCategories.subscribe(data => {
      this.categories = data;
    });
  }

  getCategoryPost(){
    this.category_view =  this.categories.filter((category: { id: number; }) =>{
        return category.id == this.post.idCategory? category: "";
    })[0].title;
  }

  getCategoryIdByTitle(title:string){
    this.idCategory_view =  this.categories.filter((category: { title:string; }) =>{
        return category.title == title? category: 0;
    })[0].id;
  }

  getPostById(id:any){
    this.service.currentPosts.subscribe(data =>{
        this.posts = data;
        this.post = this.posts.filter(function(post: { id: number; }){
          return post.id == id? post: 0;
      });
    });
      this.post = this.post[0];
  }

  ConvertDateToString(publicationDate_view:any){
    let day = this.publicationDate_view.day<10?("0"+ this.publicationDate_view.day):  this.publicationDate_view.day;
    let month = this.publicationDate_view.month<10?("0"+ this.publicationDate_view.month):  this.publicationDate_view.month;
    let year = this.publicationDate_view.year;
    this.publicationDate_view = year +"-"+month+"-"+day;
  }

  onSelected(value:string): void {
 		this.category_view = value;
 	}

  onSubmit() {
    this.isFormSubmitted = true;
    if (this.postForm.valid) {
      console.log("Form Submitted!");
      this.SavePost();
      this.postForm.reset();      
    }
}

  SavePost(){
    this.getCategoryIdByTitle(this.category_view);
    this.ConvertDateToString(this.publicationDate_view)

    var val = {
      Id:0,
      Title:this.title_view,
      PublicationDate:this.publicationDate_view,
      Content:this.content_view,
      IdCategory:this.idCategory_view
    };
    if(this.post == undefined){    
      this.service.addPost(val).subscribe(
        res =>{
          this.service.filter("Ok")
          this.router.navigate(['home'])
          alert(res);   
          
        },
         status=>{ if(status.status == 200){
            alert("Created Successfully!!")
          }  
          if(status.status == 406){
            alert("This category has posts attached and cannot be deleted")
          }      
          if(status.status == 500){
            alert("Internal error")
          }    
        }
      )
    }else{
      val.Id =  this.post.id;
      var publicationDatePost = new NgbDate(
        new Date(this.post.publicationDate).getFullYear(),
        new Date(this.post.publicationDate).getMonth() + 1,
        new Date(this.post.publicationDate).getDate()
      );
      if(this.post.title != this.title_view || this.post.idCategory != this.idCategory_view || publicationDatePost != this.publicationDate_view || this.post.content != this.content_view){
         this.service.updatePost(val).subscribe(  
       res =>{
         this.service.filter("Ok")
          this.router.navigate(['home'])   
          alert(res);          
        },
         status=>{ if(status.status == 200){
            alert("Updated Successfully!!")
          }  
          if(status.status == 406){
            alert("This category has posts attached and cannot be deleted")
          }      
          if(status.status == 500){
            alert("Internal error")
          }    
        })
      }
    }
    this.router.navigate(['home'])
  }


  Close(){
    this.service.filter("Ok")
    this.router.navigate(['home'])
  }

}
