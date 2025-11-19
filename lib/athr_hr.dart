import 'package:athr_hr/core/app_cubit/app_cubit.dart';
import 'package:athr_hr/core/app_cubit/app_state.dart';
import 'package:athr_hr/core/localization/app_localizations_setup.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_pref_keys.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_preferences_helper.dart';
import 'package:athr_hr/di/di.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class AthrHr extends StatelessWidget {
  const AthrHr({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => getIt<AppCubit>()..getSavedLanguage(),
      child: ScreenUtilInit(
        designSize: const Size(375, 812),
        minTextAdapt: true,
        splitScreenMode: true,
        child: BlocBuilder<AppCubit, AppStates>(
          buildWhen: (previous, current) {
            return previous != current;
          },
          builder: (context, child) {
            final cubit = context.read<AppCubit>();
            return MaterialApp(
              theme: ThemeData(
                fontFamily: 'Cairo',
              ),
              debugShowCheckedModeBanner: false,
              locale: Locale(cubit.currentLanguage),
              supportedLocales: AppLocalizationsSetup.supportedLocales,
              localeResolutionCallback:
                  AppLocalizationsSetup.localeResolutionCallback,
              localizationsDelegates:
                  AppLocalizationsSetup.localizationsDelegates,
              initialRoute: _getInitialRoute(),
              onGenerateRoute: AppRoutes.onGenerateRoute,
              builder: (context, child) {
                return Scaffold(body: child);
              },
            );
          },
        ),
      ),
    );
  }

  String _getInitialRoute() {
    final token = SharedPrefHelper().getString(key: SharedPrefKeys.tokenKey);
    return token != null ? AppRoutes.personalDataView : AppRoutes.personalDataView;
  }
}
