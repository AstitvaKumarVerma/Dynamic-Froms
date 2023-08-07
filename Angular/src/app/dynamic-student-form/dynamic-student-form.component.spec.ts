import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicStudentFormComponent } from './dynamic-student-form.component';

describe('DynamicStudentFormComponent', () => {
  let component: DynamicStudentFormComponent;
  let fixture: ComponentFixture<DynamicStudentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DynamicStudentFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DynamicStudentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
