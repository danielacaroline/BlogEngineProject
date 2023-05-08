import { Component, OnInit, Input } from '@angular/core';
import { AddEditPostComponent } from './add-edit-post/add-edit-post.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  constructor(private router: Router) {}

  ngOnInit(): void {
  }

  addPost(){
    this.router.navigate(['post'])
  }
 
}
