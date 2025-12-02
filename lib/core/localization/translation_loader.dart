import 'dart:convert';
import 'package:flutter/services.dart';

class TranslationsLoader {
  static Map<String, dynamic> translations = {};

  static Future<void> loadTranslations(String languageCode) async {
    final String data = await rootBundle.loadString('translations/$languageCode.json');

    translations = jsonDecode(data);
  }
  static String translate(String key) {
    return translations[key] ?? key;
  }
}
