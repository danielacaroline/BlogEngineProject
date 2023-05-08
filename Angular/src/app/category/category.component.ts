import { Component, OnInit, Input } from '@angular/core';
import { AddEditCategoryComponent } from './add-edit-category/add-edit-category.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {


  constructor(private modal: NgbModal) {}

  ngOnInit(): void {
  }

  addCategory(){
    const modalRef = this.modal.open(AddEditCategoryComponent);
    modalRef.componentInstance.modalTitle = "Blog - Add Category"; 
    modalRef.componentInstance.newCategory =  true;
  }  
 
}
