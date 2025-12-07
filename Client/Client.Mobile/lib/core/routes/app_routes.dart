import 'package:athr_hr/core/routes/base_routes.dart';
import 'package:athr_hr/features/auth/change_password/view/change_password_view.dart';
import 'package:athr_hr/features/auth/login/view/login_view.dart';
import 'package:athr_hr/features/leaves/view/leave_request_view.dart';
import 'package:athr_hr/features/main/main_view.dart';
import 'package:athr_hr/features/on_boarding/on_boarding.dart';
import 'package:athr_hr/features/profile/view/profile_details_view.dart';
import 'package:athr_hr/features/profile/view/profile_view.dart';
import 'package:athr_hr/features/tasks/view/tasks_view.dart';
import 'package:athr_hr/features/times/view/time_view.dart';
import 'package:flutter/material.dart';


class AppRoutes {
  static const String login = '/';
  static const String register = 'register';
  static const String onBoarding = 'onBoarding';
  static const String profile = 'profile';
  static const String changePassword = 'changePassword';
  static const String mainView = 'main';
  static const String personalDataView = 'personalDataView';
  static const String leaveRequestView = 'leaveRequestView';
  static const String createTaskView = 'createTaskView';
  static const String tasksView = 'tasksView';
  static const String tasksDetailsView = 'tasksDetailsView';
  static const String timesView = 'timesView';

  static Route<void> onGenerateRoute(RouteSettings settings) {
    switch (settings.name) {
      case onBoarding:
        return
          BaseRoute(
              page:
          OnBoarding());
        case login:
        return BaseRoute(
            page:
         const LoginView(),
            );
        case profile:
        return BaseRoute(
            page:
         const ProfileView(),
            );
        case changePassword:
        return BaseRoute(
            page:
         const ChangePasswordView(),
            );
        case mainView:
        return BaseRoute(
            page:
         const MainScreen(),
            );
        case personalDataView:
        return BaseRoute(
            page:
         const ProfileDetailsView(),
            );
        case leaveRequestView:
        return BaseRoute(
          page:
          const LeaveRequestView(),
        );
        case tasksView:
        return BaseRoute(
          page:
          const TasksView(),
        );
      case timesView:
        return BaseRoute(
          page:
          const TimeView(),
        );
      default:
        return BaseRoute(page:SizedBox());
    }
  }
}
