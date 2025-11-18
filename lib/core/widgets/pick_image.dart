import 'dart:io';
import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:image_picker/image_picker.dart';

Future<File?> pickImage(BuildContext context) async {
  final ImagePicker picker = ImagePicker();

  final source = await showDialog<ImageSource>(
    context: context,
    builder: (context) => AlertDialog(
      backgroundColor: Colors.teal,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(20),
      ),
      content: SizedBox(
        height: 120,
        width: 350.w,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            ListTile(
              leading: Icon(Icons.photo_library, color: Colors.grey, size: 18.sp),
              title: Text(
                context.translate(LangKeys.gallery),
                style: MyFonts.styleMedium500_14.copyWith(color: MyColors.white),
              ),
              onTap: () => Navigator.pop(context, ImageSource.gallery),
            ),
            ListTile(
              leading: Icon(Icons.camera_alt, color: Colors.grey, size: 18.sp),
              title: Text(
                context.translate(LangKeys.camera),
                style: MyFonts.styleMedium500_14.copyWith(color: MyColors.white),
              ),
              onTap: () => Navigator.pop(context, ImageSource.camera),
            ),
          ],
        ),
      ),
    ),
  );

  if (source == null) return null;

  final pickedFile = await picker.pickImage(source: source);

  if (pickedFile == null) return null;

  return File(pickedFile.path);
}
