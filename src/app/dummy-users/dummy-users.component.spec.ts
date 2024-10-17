import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DummyUsersComponent } from './dummy-users.component';

describe('DummyUsersComponent', () => {
  let component: DummyUsersComponent;
  let fixture: ComponentFixture<DummyUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DummyUsersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DummyUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
