import { Component, OnInit, Input} from '@angular/core';
import { SharedService } from "src/app/shared.service";
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, FormControl  } from '@angular/forms';

@Component({
  selector: 'app-add-edit-category',
  templateUrl: './add-edit-category.component.html',
  styleUrls: ['./add-edit-category.component.scss']
})
export class AddEditCategoryComponent implements OnInit {
  @Input() category:any;
  id_view:any = 0;
  title_view: any ="";
  modalTitle: any ="";
  newCategory: boolean =  false;
  title!: FormControl;
  categoryForm!: FormGroup;

  isFormSubmitted:boolean = false;

  constructor(private service: SharedService, public modal: NgbActiveModal,  public fb: FormBuilder ){ }

  ngOnInit() : void {
    this.createFormControls();
    this.createForm();

    this.id_view = this.category.id;
    this.title_view = this.category.title;
    this.modalTitle =  this.modalTitle;
    this.newCategory = this.newCategory
  }

  createFormControls() {
    this.title = new FormControl('', [ Validators.minLength(3)]);
  }

  createForm() {
    this.categoryForm = new FormGroup({
      title: this.title
    });
  } 

  onSubmit() {
    this.isFormSubmitted = true;
    if (this.categoryForm.valid) {
      console.log("Form Submitted!");
      this.SaveCategory();
      this.modal.close(); 
      this.categoryForm.reset();      
    }
}

  SaveCategory() {
    var val = {
      Id:this.id_view,
      Title:this.title_view
    };

    if (this.newCategory){
      this.service.addCategory(val).subscribe(
        res =>{
          alert(res);  
          this.service.filter("Ok")   
        },
         status=>{ 
          if(status.status == 200){
            alert("Created Successfully!!");
          }       
          if(status.status == 500){
            alert("Internal error");
          }    
        });
   }
  else{
      if(this.category.title != this.title_view){ 
        this.service.updateCategory(val).subscribe(
          res =>{   
            alert(res);     
          },
           status=>{ 
            if(status.status == 200){
              alert("Updated Successfully!!");
            }       
            if(status.status == 500){
              alert("Internal error");
            }    
          });
    }}  
    this.onClose()    
  }

  onClose(){   
    this.modal.close();
    this.service.filter("Ok")
  }

}
