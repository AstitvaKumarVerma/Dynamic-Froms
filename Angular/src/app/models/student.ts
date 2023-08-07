export class Student {
    value(value: any) {
      throw new Error('Method not implemented.');
    }
    studentName: string | undefined;
    addStudentMarks: SubjectMarks[] | undefined;
  }
  
  export class SubjectMarks {
    subjectName: string = '';
    marks: number = 0;
}
