import { Component, EventEmitter, OnInit, Output }  from '@angular/core';
import { SharedService } from "src/app/shared.service";
import { AddEditCategoryComponent } from '../add-edit-category/add-edit-category.component';
import { ConfirmDeleteComponent } from 'src/app/confirm-delete/confirm-delete.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
    selector: 'app-view-categories',
    templateUrl: './view-categories.component.html',
    styleUrls: ['./view-categories.component.scss']
})
export class ViewCategoriesComponent implements OnInit { 
    Categories: any = [];
    Category: any;

    constructor(private service: SharedService, private modal: NgbModal) {
      this.service.listen().subscribe((m:any)=>{
        this.refreshCategoryList();
      })
     }

    ngOnInit(): void {
      this.refreshCategoryList();     
    }

    refreshCategoryList() {
        this.service.getCategories().subscribe(data => {
          this.Categories = data;
          this.sendCategoriesToService();
        });
        
      }

    sendCategoriesToService() {
        this.service.setCategories(this.Categories);
    }
    
    editCategory(item: any) {
      const modalRef = this.modal.open(AddEditCategoryComponent);
      modalRef.componentInstance.category = item;  
      modalRef.componentInstance.modalTitle =  "Blog - Edit Category";
      modalRef.componentInstance.newCategory =  false;
    }

    deleteConfirm(item: any) {
      const modalRef = this.modal.open(ConfirmDeleteComponent);  
      modalRef.result.then((data) => {
        if (data == "Ok"){
            this.deleteCategory(item);
        }
      });
    }
      
   deleteCategory(item: any) {
    this.service.deleteCategory(item.id).subscribe(
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
