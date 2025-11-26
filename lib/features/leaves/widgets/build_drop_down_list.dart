import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

void showLeaveDropdown({
  required BuildContext context,
  required TextEditingController controller,
  required List<String> options,
  required GlobalKey fieldKey,
}) {
  final RenderBox renderBox = fieldKey.currentContext!.findRenderObject() as RenderBox;
  final offset = renderBox.localToGlobal(Offset.zero);

  OverlayEntry? overlayEntry;

  overlayEntry = OverlayEntry(
    builder: (context) => Positioned(
      left: offset.dx,
      top: offset.dy + renderBox.size.height + 5,
      child: Material(
        elevation: 4,
        borderRadius: BorderRadius.circular(8.sp),
        child: SizedBox(
          width: 100.w,
          height: 220.h,
          child: SingleChildScrollView(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: options.map((option) {
                return InkWell(
                  onTap: () {
                    controller.text = option;
                    overlayEntry?.remove();
                  },
                  child: Container(
                    width: double.infinity,
                    padding: EdgeInsets.symmetric(horizontal: 16.w, vertical: 12.h),
                    child: Text(
                      option,
                      style: MyFonts.semiBold600_18.copyWith(
                        color: MyColors.black,
                      ),
                    ),
                  ),
                );
              }).toList(),
            ),
          ),
        ),
      ),
    ),
  );

  Overlay.of(context).insert(overlayEntry);
}
