import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../services/api.service';
import { Student } from '../models/student';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-dynamic-student-form',
  templateUrl: './dynamic-student-form.component.html',
  styleUrls: ['./dynamic-student-form.component.css']
})
export class DynamicStudentFormComponent implements OnInit {
  WholeScreenHeight: number = 100;

  isShow: boolean = false;

  studentForm: FormGroup;
  mrks: any;

  constructor(private fb: FormBuilder, private ServiceCall: ApiService, private router: Router, private snackBar: MatSnackBar) {
    this.studentForm = this.fb.group({
      studentName: ['', Validators.required],
      addStudentMarks: this.fb.array([])
    });


  }

  ngOnInit(): void {
  }

  get subjects() {
    return this.studentForm.get('addStudentMarks') as FormArray;
  }

  get f() {
    return this.studentForm.controls;
  }


  addSubject() {
    this.WholeScreenHeight += 30;
    const subjectGroup = this.fb.group({
      subjectName: ['', Validators.required],
      marks: ['', [Validators.required, Validators.pattern, Validators.min(0), Validators.max(100)]]
    });

    this.subjects.push(subjectGroup);
  }


  valid(val: any) {
    if (val.key == 'E' || val.key == 'e' || val.key == '.' || val.key == '+') {
      val.preventDefault();
    }
  }


  removeSubject(index: number) {
    this.subjects.removeAt(index);
  }


  onSubmit(data: Student) {
    console.log(data)
    console.log('Form Submitted:', data);
    console.log('Form Valid:', this.studentForm.valid);

    if (this.studentForm.valid) {

      if (confirm("Are you sure to Add Marks ?")) {
        this.ServiceCall.AddStudentMarksApi(data).subscribe((res: any) => {
          this.snackBar.open('Marks Add Successfully....', 'Undo', {
            duration: 1000
          });
          this.studentForm.reset();
          this.router.navigate(['']);
        });
      }
     
    } 
    
    else {
      alert('Please fill all the required fields.');
    }
  }

}
