import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';

List<String> getArabicWeekDays(BuildContext context) {
  return [
    context.translate(LangKeys.monday),
    context.translate(LangKeys.tuesday),
    context.translate(LangKeys.wednesday),
    context.translate(LangKeys.thursday),
    context.translate(LangKeys.friday),
    context.translate(LangKeys.saturday),
    context.translate(LangKeys.sunday),
  ];
}

List<String> getArabicMonths(BuildContext context) {
  return [
    context.translate(LangKeys.monthJanuary),
    context.translate(LangKeys.monthFebruary),
    context.translate(LangKeys.monthMarch),
    context.translate(LangKeys.monthApril),
    context.translate(LangKeys.monthMay),
    context.translate(LangKeys.monthJune),
    context.translate(LangKeys.monthJuly),
    context.translate(LangKeys.monthAugust),
    context.translate(LangKeys.monthSeptember),
    context.translate(LangKeys.monthOctober),
    context.translate(LangKeys.monthNovember),
    context.translate(LangKeys.monthDecember),
  ];
}

Future<DateTime?> pickDate({
  required BuildContext context,
  DateTime? initialDate,
  DateTime? firstDate,
  DateTime? lastDate,
}) async {
  DateTime? selectedDate = await showDatePicker(
    context: context,
    initialDate: initialDate ?? DateTime.now(),
    firstDate: firstDate ?? DateTime(2000),
    lastDate: lastDate ?? DateTime(2100),
    builder: (context, child) {
      return Theme(
        data: Theme.of(context).copyWith(
          colorScheme: ColorScheme.light(
            primary: MyColors.rememberPasswordColor,
            onPrimary: Colors.white,
            onSurface: Colors.black,
          ),
          textButtonTheme: TextButtonThemeData(
            style: TextButton.styleFrom(
              foregroundColor: MyColors.rememberPasswordColor,
            ),
          ),
        ),
        child: child!,
      );
    },
  );

  return selectedDate;
}

String formatDateToArabic(BuildContext context, DateTime date) {
  final weekDays = getArabicWeekDays(context);
  final months = getArabicMonths(context);

  String weekDay = weekDays[date.weekday - 1];
  String month = months[date.month - 1];

  return "$weekDay ${date.day} $month ${date.year}";
}
