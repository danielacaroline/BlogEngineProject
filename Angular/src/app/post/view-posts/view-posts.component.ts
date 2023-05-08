import { Component, OnInit } from '@angular/core';
import { SharedService } from "src/app/shared.service";
import { AddEditPostComponent } from '../add-edit-post/add-edit-post.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDeleteComponent } from 'src/app/confirm-delete/confirm-delete.component';

@Component({
  selector: 'app-view-posts',
  templateUrl: './view-posts.component.html',
  styleUrls: ['./view-posts.component.scss']
})
export class ViewPostsComponent  implements OnInit {
  Posts: any = [];

  constructor(private service: SharedService, private modal: NgbModal){ 
    this.service.listen().subscribe((m:any)=>{
      this.refreshPostList();
    })
   }

  ngOnInit(): void {
    this.refreshPostList();    
  }

  refreshPostList() {
      this.service.getPosts().subscribe(data => {
        this.Posts = data;
        this.sendPostsToService();
      });
    }
  
  sendPostsToService() {
      this.service.setPosts(this.Posts);
  }

  deleteConfirm(item: any) {
    const modalRef = this.modal.open(ConfirmDeleteComponent);  
    modalRef.result.then((data) => {
      if (data == "Ok"){
          this.deletePost(item);
      }
    });
  }
    
  deletePost(item: any) {
    this.service.deletePost(item.id).subscribe(  
      res =>{
        alert(res);  
        this.service.filter("Ok") 
      },
      status=>{ if(status.status == 200){
        alert("Deleted Successfully!!")
      }  
      if(status.status == 406){
        alert("This category has posts attached and cannot be deleted")
      }      
      if(status.status == 500){
        alert("Internal error")
      }    
    });
  }
}