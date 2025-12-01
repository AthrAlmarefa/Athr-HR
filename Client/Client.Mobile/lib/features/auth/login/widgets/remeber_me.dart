import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class RememberMeWidget extends StatefulWidget {
  final ValueChanged<bool> onChanged;
  final bool initialValue;

  const RememberMeWidget({
    super.key,
    required this.onChanged,
    this.initialValue = false,
  });

  @override
  RememberMeWidgetState createState() => RememberMeWidgetState();
}

class RememberMeWidgetState extends State<RememberMeWidget> {
  late bool isChecked;

  @override
  void initState() {
    super.initState();
    isChecked = widget.initialValue;
  }

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        setState(() {
          isChecked = !isChecked;
          widget.onChanged(isChecked);
        });
      },
      child: Row(
        mainAxisAlignment: MainAxisAlignment.start,
        children: [
          Container(
            decoration: BoxDecoration(
              color: isChecked
                  ? MyColors.rememberPasswordColor
                  : Colors.transparent,
              borderRadius: BorderRadius.circular(5),
              border: Border.all(
                color: isChecked
                    ? Colors.transparent
                    : MyColors.rememberPasswordColor,
                width: 2,
              ),
            ),
            width: 16.w,
            height: 16.h,
            child: isChecked
                ? Icon(Icons.check, color: MyColors.white, size: 12.sp)
                : null,
          ),
          SizedBox(width: 12.w),
          Text(
            context.translate(LangKeys.rememberPassword),
            style: MyFonts.styleMedium500_16.copyWith(color: MyColors.black),
          ),
        ],
      ),
    );
  }
}
