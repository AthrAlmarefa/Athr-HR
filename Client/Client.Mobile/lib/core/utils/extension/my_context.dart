import 'package:athr_hr/core/localization/app_localization.dart';
import 'package:flutter/material.dart';

extension MyContext on BuildContext {
  double get width => MediaQuery.of(this).size.width;
  double get height => MediaQuery.of(this).size.height;

  bool get isLandScape =>
      MediaQuery.of(this).orientation == Orientation.landscape;

  bool get isPortrait =>
      MediaQuery.of(this).orientation == Orientation.portrait;

  String translate(String key) {
    return AppLocalizations.of(this)?.translate(key) ?? key;
  }
}
