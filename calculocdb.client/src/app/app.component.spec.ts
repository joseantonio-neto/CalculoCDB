import { HttpTestingController, provideHttpClientTesting, } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { provideToastr } from 'ngx-toastr';
import { provideHttpClient } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [ReactiveFormsModule, FormsModule],
      providers: [provideToastr(), provideHttpClient(), provideHttpClientTesting()]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.debugElement.componentInstance;
    fixture.detectChanges();
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it(`should have the 'Cálculo de CDB' title`, () => {
    expect(component.title).toEqual('Cálculo de CDB');
  });

  it('should render the H1 element', () => {
    const compiled = fixture.debugElement.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Cálculo de CDB');
  });

  it('should the form be valid, button is disabled and fetch function called', async () => {
    const compiled = fixture.debugElement.nativeElement as HTMLElement;

    const initialValueInput = compiled.querySelector('input[name=initialValue]') as HTMLInputElement;
    const monthsInput = compiled.querySelector('input[name=months]') as HTMLInputElement;
    initialValueInput.value = '1000';
    initialValueInput.dispatchEvent(new Event('input'));
    monthsInput.value = '10';
    monthsInput.dispatchEvent(new Event('input'));

    // Form is valid
    const isFormValid = component.calculateForm.valid
    expect(isFormValid).toBeTruthy();

    fixture.detectChanges();
    await fixture.whenStable();

    // Button is enable
    const buttonInput = compiled.querySelector('input[type=submit]') as HTMLInputElement;
    const isButtonEnable = !buttonInput.disabled;
    expect(isButtonEnable).toBeTruthy();

    spyOn(component, 'fetchCalculateCdb');

    buttonInput.click();

    expect(component.fetchCalculateCdb).toHaveBeenCalledTimes(1);
  });
});
