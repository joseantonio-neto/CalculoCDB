import { TestBed } from '@angular/core/testing';
import { CalculateCdbService } from './calculate-cdb.service';
import { HttpErrorResponse, provideHttpClient } from '@angular/common/http';
import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { GetCalculateResponse } from './models/getCalculateResponse';

describe('CalculateCdbService', () => {
  let service: CalculateCdbService;
  let controller: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideHttpClient(), provideHttpClientTesting()]
    });
    service = TestBed.inject(CalculateCdbService);
    controller = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should use ValueService', () => {
    const expectedCalculate = {
      initialValue: 1000,
      months: 10,
      grossIncome: 1101.56,
      netIncome: 1081.25,
      impostValue: 20.31,
      fee: 0.2
    } as GetCalculateResponse;

    let calculateDate = {} as GetCalculateResponse;
    service.getCalculate(1000, 10).subscribe((value) => {
      calculateDate = value;
    });

    const request = controller.expectOne('/calculate?initialValue=1000&months=10');
    request.flush(expectedCalculate);
    controller.verify();

    expect(expectedCalculate).toEqual(calculateDate);
  });

  it('should handle network errors and return an error response', () => {
    const status = 400;
    const statusText = 'Bad Request';
    const errorEvent = new ProgressEvent('API error');
    let errorData = {} as HttpErrorResponse;

    service.getCalculate(1000, -10).subscribe({
      next: () => {
        fail('next handler must not be called');
      },
      error: (error) => {
        errorData = error;
      }
    });

    const request = controller.expectOne('/calculate?initialValue=1000&months=-10');
    request.error(new ProgressEvent('Network error'), {
      status,
      statusText,
    });
    controller.verify();

    expect(errorData.error).toEqual(errorEvent);
    expect(errorData.status).toBe(status);
    expect(errorData.statusText).toBe(statusText);
  });
});
