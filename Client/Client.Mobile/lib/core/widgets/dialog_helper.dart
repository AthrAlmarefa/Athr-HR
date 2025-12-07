import 'package:athr_hr/features/profile/widgets/build_logout_dialog.dart';
import 'package:flutter/material.dart';

void showCustomConfirmDialog({
  required BuildContext context,
  required String title,
  required String message,
  required String cancelText,
  required String confirmText,
  required Color cancelColor,
  required Color confirmTextColor,
  Gradient? confirmGradient,
  required VoidCallback onCancel,
  required VoidCallback onConfirm,
}) {
  showDialog(
    context: context,
    barrierDismissible: false,
    builder: (context) => CustomConfirmDialog(
      title: title,
      message: message,
      cancelText: cancelText,
      confirmText: confirmText,
      cancelColor: cancelColor,
      confirmTextColor: confirmTextColor,
      confirmGradient: confirmGradient,
      onCancel: onCancel,
      onConfirm: onConfirm,
    ),
  );
}
