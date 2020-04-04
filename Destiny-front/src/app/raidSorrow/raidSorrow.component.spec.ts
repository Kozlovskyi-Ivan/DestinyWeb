/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RaidSorrowComponent } from './raidSorrow.component';

describe('RaidSorrowComponent', () => {
  let component: RaidSorrowComponent;
  let fixture: ComponentFixture<RaidSorrowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaidSorrowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaidSorrowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
