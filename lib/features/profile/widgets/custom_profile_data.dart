import 'dart:io';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/widgets/pick_image.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomProfileData extends StatefulWidget {
  final String imageUrl;
  final String name;
  final String jobDescription;
  final String id;
  final String prefix;

  const CustomProfileData({
    super.key,
    required this.imageUrl,
    required this.name,
    required this.jobDescription,
    required this.id,
    required this.prefix,
  });

  @override
  State<CustomProfileData> createState() => _CustomProfileDataState();
}

class _CustomProfileDataState extends State<CustomProfileData> {
  File? pickedImageFile;
  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        InkWell(
          onTap: () async {
            final file = await pickImage(context);
            if (file != null) {
              setState(() {
                pickedImageFile = file;
              });
            }
          },
          child: CircleAvatar(
            radius: 100,
            backgroundImage: pickedImageFile != null
                ? FileImage(pickedImageFile!)
                : const AssetImage(Assets.imagesProfilePhoto),
          ),
        ),

        SizedBox(height: 16.h),
        Text(
          widget.name,
          style: MyFonts.semiBold600_24.copyWith(color: MyColors.black),
          textAlign: TextAlign.center,
        ),
        SizedBox(height: 6.h),
        Text(
          widget.jobDescription,
          style: MyFonts.styleMedium500_14.copyWith(color: MyColors.jobColor),
          textAlign: TextAlign.center,
        ),
        SizedBox(height: 6.h),
        Text.rich(
          TextSpan(
            children: [
              TextSpan(
                text: widget.id.replaceFirst(widget.prefix, widget.id),
                style: MyFonts.styleMedium500_14.copyWith(
                  color: MyColors.black,
                ),
              ),
              TextSpan(
                text: widget.prefix,
                style: MyFonts.styleMedium500_14.copyWith(
                  color: MyColors.jobColor,
                ),
              ),
            ],
          ),
          textAlign: TextAlign.center,
        ),
      ],
    );
  }
}
