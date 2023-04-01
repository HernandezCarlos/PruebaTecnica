import { Component } from '@angular/core';
import { ActivityDTO } from './dto/activity-dto';
import { ActivitiesService } from './service/activities.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.css']
})
export class ActivitiesComponent {

  activitiesList: ActivityDTO[] = [];
  loading = false;
  msgError: string = '';

  constructor(private activitiesService: ActivitiesService) { }

  ngOnInit(): void {
    this.loading = true;
    const _subscription: Subscription = this.activitiesService.getActivities().subscribe({
      next: data => {
          this.activitiesList = data as ActivityDTO[];
          this.loading = false;
      },
      error: err => {
        this.msgError = 'Hubo un error obteniendo la información. Por favor intentelo nuevamente.'
        this.loading = false;
      },
      complete: () => {
        _subscription.unsubscribe();
      }
    })
  }

}
