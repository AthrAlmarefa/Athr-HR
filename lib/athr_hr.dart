import 'package:athr_hr/core/app_cubit/app_cubit.dart';
import 'package:athr_hr/core/app_cubit/app_state.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_pref_keys.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_preferences_helper.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'core/localization/app_localizations_setup.dart';

class AthrHr extends StatelessWidget {
  final AppCubit appCubit;

  const AthrHr({super.key, required this.appCubit});

  @override
  Widget build(BuildContext context) {
    return BlocProvider.value(
      value: appCubit,
      child: ScreenUtilInit(
        designSize: const Size(375, 812),
        minTextAdapt: true,
        splitScreenMode: true,
        builder: (context, child) {
          return BlocBuilder<AppCubit, AppStates>(
            builder: (context, state) {
              final cubit = context.read<AppCubit>();
              return MaterialApp(
                debugShowCheckedModeBanner: false,
                theme: ThemeData(fontFamily: 'Cairo'),
                locale: Locale(cubit.currentLanguage),
                supportedLocales: AppLocalizationsSetup.supportedLocales,
                localizationsDelegates: AppLocalizationsSetup.localizationsDelegates,
                initialRoute: _getInitialRoute(),
                onGenerateRoute: AppRoutes.onGenerateRoute,
              );
            },
          );
        },
      ),
    );
  }

  String _getInitialRoute() {
    final token = SharedPrefHelper().getString(key: SharedPrefKeys.tokenKey);
    return token != null ? AppRoutes.mainView : AppRoutes.mainView;
  }
}
