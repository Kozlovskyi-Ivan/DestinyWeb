/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RaidPastComponent } from './raidPast.component';

describe('RaidPastComponent', () => {
  let component: RaidPastComponent;
  let fixture: ComponentFixture<RaidPastComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaidPastComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaidPastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
