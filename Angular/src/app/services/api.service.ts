import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from '../models/student';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }

  AddStudentMarksApi(student: Student)
  {
    return this.http.post('https://localhost:7166/api/Student/AddStudentDetails',student);
  }
}
