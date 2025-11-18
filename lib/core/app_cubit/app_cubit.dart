import 'dart:ui';
import 'package:athr_hr/core/services/shared_preferences/shared_pref_keys.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_preferences_helper.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';
import 'package:url_launcher/url_launcher.dart';
import 'app_state.dart';

@injectable
class AppCubit extends Cubit<AppStates> {
  AppCubit() : super(AppInitialState());
  bool isDark = true;
  String currentLanguage = 'en';

  int selectedIndex = 0;

  // * change Language logic *

  void getSavedLanguage() {
    final result =
    SharedPrefHelper().containPreference(key: SharedPrefKeys.language)
        ? SharedPrefHelper().getString(key: SharedPrefKeys.language)
        : 'ar';
    currentLanguage = result!;
    emit(LanguageChangeState(local: Locale(currentLanguage)));
  }

  Future<void> _changeLanguage({String? langCode}) async {
    currentLanguage = langCode!;

    await SharedPrefHelper()
        .setString(key: SharedPrefKeys.language, stringValue: currentLanguage);
    emit(LanguageChangeState(local: Locale(currentLanguage)));
  }
  // * Url Launcher *

  Future<void> openUrl({required String url}) async {
    if (!await launchUrl(Uri.parse(url),mode: LaunchMode.externalApplication)) {
      throw 'Could not launch $url';
    }
  }

  void toArabic() => _changeLanguage(langCode: 'ar');

  void toEnglish() => _changeLanguage(langCode: 'en');

  Future<void> updateIndex(int index) async {
    selectedIndex = index;

    emit(UpdateIndexState());
  }
}