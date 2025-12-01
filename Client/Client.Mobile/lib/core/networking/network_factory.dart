import 'package:athr_hr/core/api/api_constants.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_pref_keys.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_preferences_helper.dart';
import 'package:athr_hr/di/di.dart';
import 'package:injectable/injectable.dart';
import 'package:dio/dio.dart';

@module
abstract class NetworkFactory {
  @lazySingleton
  Dio provideDio() {
    final dio = Dio();
    dio.options = BaseOptions(
      connectTimeout: const Duration(seconds: 60),
      receiveTimeout: const Duration(seconds: 60),
      baseUrl: ApiConstants.baseUrl,
    );
    dio.interceptors.add(getIt<LogInterceptor>());
    dio.interceptors.add(
      InterceptorsWrapper(
        onRequest: (options, handler) {
          options.headers['Authorization'] =
              'Bearer ${SharedPrefHelper().getString(key: SharedPrefKeys.tokenKey)}';
          return handler.next(options);
        },
        onError: (error, handler) {
          if (error.response != null) {
            if (error.response!.statusCode == 401) {
              // Handle 400 or 401 error
              // SharedPrefHelper().clearPreferences();
              // Navigate to login screen or handle error accordingly
            }
          }
          return handler.next(error);
        },
      ),
    );
    return dio;
  }

  LogInterceptor providerInterceptor() {
    return LogInterceptor(
      error: true,
      request: true,
      requestBody: true,
      requestHeader: true,
      responseBody: true,
      responseHeader: true,
    );
  }
}

abstract class NetworkModule {}
