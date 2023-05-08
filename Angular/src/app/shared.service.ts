import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, BehaviorSubject } from "rxjs";
import { HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';

const headers= new HttpHeaders()
.set('content-type', 'application/json')
.set('Access-Control-Allow-Origin', '*');

@Injectable({
  providedIn: 'root'
})

export class SharedService {
    private categories = new BehaviorSubject("")
    currentCategories = this.categories.asObservable();
    private posts = new BehaviorSubject("")
    currentPosts = this.posts.asObservable();

    readonly APIUrl = "https://localhost:7188/api/BlogEngine";
    constructor(private http: HttpClient) { }   

    getCategories(): Observable<any[]> {
      return this.http.get<any>(this.APIUrl + '/categories',  { 'headers': headers });
    }

    addCategory(val: any): Observable<any> {
     return this.http.post<any>(this.APIUrl + '/categories', val);
    }

    updateCategory(val: any): Observable<any> {
     return this.http.put<any>(this.APIUrl + '/categories', val,  { 'headers': headers });
    }

    deleteCategory(id: any): Observable<any> {
     return this.http.delete<any>(this.APIUrl + '/categories/' + id);
    }

    getPosts(): Observable<any[]> {
      return this.http.get<any>(this.APIUrl + '/all-posts',  { 'headers': headers });
    }

    addPost(val: any): Observable<any> {
     return this.http.post<any>(this.APIUrl + '/posts', val,  { 'headers': headers });
    }

    updatePost(val: any): Observable<any> {
     return this.http.put<any>(this.APIUrl + '/posts', val,  { 'headers': headers });
    }

    deletePost(id: any): Observable<any> {
     return this.http.delete<any>(this.APIUrl + '/posts/' + id,  { 'headers': headers });
    }
    
    setCategories(val: any) {
      this.categories.next(val);
    }

    setPosts(val: any) {
      this.posts.next(val);
    }

    private _listners = new Subject<any>();
    listen(): Observable<any>{
      return this._listners.asObservable();
    }
    filter(filterBy: string){
      this._listners.next(filterBy);
    }
}
