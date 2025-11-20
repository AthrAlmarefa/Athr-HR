import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomTextFormField extends StatefulWidget {
  const CustomTextFormField({
    super.key,
    this.isPassword,
    this.hintText,
    this.labelText,
    this.controller,
    this.suffix,
    this.validator,
    this.prefix,
    this.hintStyle,
  });

  final String? hintText;
  final String? labelText;
  final dynamic controller;
  final bool? isPassword;
  final Widget? suffix;
  final Widget? prefix;
  final String? Function(String?)? validator;
  final TextStyle? hintStyle;

  @override
  State<CustomTextFormField> createState() => _CustomTextFormFieldState();
}

class _CustomTextFormFieldState extends State<CustomTextFormField> {
  @override
  Widget build(BuildContext context) {
    return TextFormField(
      obscureText: widget.isPassword ?? false,
      controller: widget.controller,
      decoration: InputDecoration(
        errorStyle: TextStyle(fontSize: 12.sp, color: MyColors.redColor),
        prefixIcon: widget.prefix == null
            ? null
            : Padding(
                padding: EdgeInsets.symmetric(horizontal: 8.w),
                child: widget.prefix,
              ),
        prefixIconConstraints: BoxConstraints(minHeight: 0, minWidth: 0),
        suffixIcon: widget.suffix == null
            ? null
            : Padding(
                padding: EdgeInsets.symmetric(horizontal: 8.w),
                child: widget.suffix,
              ),
        suffixIconConstraints: BoxConstraints(minHeight: 0, minWidth: 0),
        hintText: widget.hintText ?? '',
        hintStyle:
            widget.hintStyle ??
            TextStyle(color: MyColors.black, fontSize: 12.sp),
        contentPadding: EdgeInsets.symmetric(vertical: 14.h, horizontal: 12.w),
        floatingLabelBehavior: FloatingLabelBehavior.always,
        labelStyle: TextStyle(color: Colors.transparent, fontSize: 16.sp),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(12.sp)),
        enabledBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12.sp),
          borderSide: BorderSide(color: MyColors.textFormFieldBoarder),
        ),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12.sp),
          borderSide: BorderSide(color: MyColors.textFormFieldBoarder),
        ),
      ),
      validator: widget.validator,
    );
  }
}
