import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetCalculateResponse } from './models/getCalculateResponse';

@Injectable({
  providedIn: 'root',
})
export class CalculateCdbService {
  url = '/calculate';

  constructor(private readonly http: HttpClient) { }

  getCalculate(
    initialValue: number,
    months: number
  ): Observable<GetCalculateResponse> {
    return this.http.get<GetCalculateResponse>(
      `${this.url}?initialValue=${initialValue}&months=${months}`,
      { headers: { Accept: 'application/json' } }
    );
  }
}
