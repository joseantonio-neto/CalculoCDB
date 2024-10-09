import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { GetCalculateResponse } from './services/models/getCalculateResponse'
import { provideHttpClient } from '@angular/common/http';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      //imports: [HttpClientTestingModule],
      providers: [
        provideHttpClient(),
        provideHttpClientTesting()]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve calculate data from the server', () => {
    const mockCalculate = {
      initialValue: 1000,
      months: 10,
      grossIncome: 1101.56,
      netIncome: 1081.25,
      impostValue: 20.31,
      fee: 0.2
    } as GetCalculateResponse;

    const req = httpMock.expectOne('/calculate');
    expect(req.request.method).toEqual('GET');
    req.flush(mockCalculate);

    expect(component.calculateData).toEqual(mockCalculate);
  });
});
