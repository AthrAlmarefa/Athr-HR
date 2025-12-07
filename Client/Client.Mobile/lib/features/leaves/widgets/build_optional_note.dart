import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildOptionalNote extends StatefulWidget {
  final String titleText;
  final String hintText;
  final TextEditingController? controller;

  const BuildOptionalNote({
    super.key,
    required this.titleText,
    required this.hintText,
    this.controller,
  });

  @override
  State<BuildOptionalNote> createState() => _BuildOptionalNoteState();
}

class _BuildOptionalNoteState extends State<BuildOptionalNote> {
  late TextEditingController textController;

  @override
  void initState() {
    super.initState();
    textController = widget.controller ?? TextEditingController();
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Align(
          alignment: Alignment.centerRight,
          child: Text(
            widget.titleText,
            style: MyFonts.styleMedium500_16.copyWith(
              color: MyColors.black,
            ),
          ),
        ),
        SizedBox(height: 6.h),
        SizedBox(
          width: 398.w,
          height: 145.h,
          child: CustomTextFormField(
            controller: textController,
            maxLines: 10,
            expands: false,
            textAlignVertical: TextAlignVertical.top,
            hintText: widget.hintText,
            hintStyle: MyFonts.semiBold600_16.copyWith(
              color: MyColors.black,
            ),
          ),
        ),
      ],
    );
  }
}
