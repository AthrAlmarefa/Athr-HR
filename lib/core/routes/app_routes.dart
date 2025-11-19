import 'package:athr_hr/core/routes/base_routes.dart';
import 'package:athr_hr/features/auth/change_password/view/change_password_view.dart';
import 'package:athr_hr/features/auth/login/view/login_view.dart';
import 'package:flutter/material.dart';


class AppRoutes {
  static const String login = '/';
  static const String register = 'register';
  static const String onBoarding = 'onBoarding';
  static const String profile = 'profile';
  static const String changePassword = 'changePassword';
  static const String mainView = 'main';
  static const String personalDataView = 'personalDataView';

  static Route<void> onGenerateRoute(RouteSettings settings) {
    switch (settings.name) {
        case login:
        return BaseRoute(
            page:
         const LoginView(),
            );
      case changePassword:
        return BaseRoute(page: ChangePasswordView());
      default:
        return BaseRoute(page:SizedBox());
    }
  }
}
